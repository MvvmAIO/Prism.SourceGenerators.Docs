#!/usr/bin/env node
/**
 * One-time content migration: MkDocs admonitions → VitePress, .md links → cleanUrls paths.
 */
import fs from 'node:fs'
import path from 'node:path'

const docsRoot = path.resolve(import.meta.dirname, '../docs')

const ADMONITION_MAP = {
  success: 'tip',
  note: 'info',
  info: 'info',
  warning: 'warning',
  danger: 'danger',
  tip: 'tip',
}

function detectLocale(filePath) {
  const rel = path.relative(docsRoot, filePath).replace(/\\/g, '/')
  if (rel.startsWith('zh-cn/')) return 'zh-cn'
  if (rel.startsWith('ja/')) return 'ja'
  return 'en'
}

function localePrefix(locale) {
  if (locale === 'zh-cn') return '/zh-cn'
  if (locale === 'ja') return '/ja'
  return ''
}

function convertAdmonitions(content) {
  const lines = content.split('\n')
  const out = []
  let i = 0

  while (i < lines.length) {
    const match = lines[i].match(/^!!!\s+(\w+)(?:\s+"([^"]*)")?\s*$/)
    if (!match) {
      out.push(lines[i])
      i++
      continue
    }

    const kind = ADMONITION_MAP[match[1]] ?? 'info'
    const title = match[2]
    const open = title ? `::: ${kind} ${title}` : `::: ${kind}`
    out.push(open)
    i++

    while (i < lines.length) {
      const line = lines[i]
      if (line.match(/^!!!\s+\w+/)) break
      if (line.trim() === '' && i + 1 < lines.length && lines[i + 1].match(/^!!!\s+\w+/)) {
        break
      }
      if (line.startsWith('    ') || line.trim() === '') {
        out.push(line.startsWith('    ') ? line.slice(4) : line)
        i++
      } else if (line.match(/^#{1,6}\s/) || line.startsWith('---') || line.startsWith('|')) {
        break
      } else {
        break
      }
    }
    out.push(':::')
  }

  return out.join('\n')
}

function resolveMdLink(link, fileDir, locale) {
  if (/^(https?:|mailto:|#)/.test(link)) return link
  if (link.startsWith('/')) return link.replace(/\.md(\/?|#)/g, (_, p) => (p === '/' ? '/' : p))

  let target = link
  const hashIdx = target.indexOf('#')
  const hash = hashIdx >= 0 ? target.slice(hashIdx) : ''
  const pathPart = hashIdx >= 0 ? target.slice(0, hashIdx) : target

  if (!pathPart.endsWith('.md')) {
    return link
  }

  const withoutMd = pathPart.slice(0, -3)
  let resolved = path.normalize(path.join(fileDir, withoutMd)).replace(/\\/g, '/')

  // Strip docs root relative
  const docsRel = path.relative(docsRoot, path.join(fileDir, withoutMd)).replace(/\\/g, '/')

  let routePath = docsRel.replace(/\.md$/i, '')
  if (routePath.endsWith('/index') || routePath === 'index') {
    routePath = routePath.replace(/\/?index$/i, '') || ''
  }

  const prefix = localePrefix(locale)
  if (routePath.startsWith('zh-cn/')) {
    routePath = routePath.slice(6)
    const p = prefix || '/zh-cn'
    return `${p}/${routePath}${hash}`.replace(/\/+/g, '/').replace(/\/\//, '/').replace(/\/$/, '') + (routePath === '' ? '/' : '') || `${prefix}/`
  }
  if (routePath.startsWith('ja/')) {
    routePath = routePath.slice(3)
    return `/ja/${routePath}${hash}`.replace(/\/+/g, '/')
  }

  if (locale === 'zh-cn') {
    return `${prefix}/${routePath}${hash}`.replace(/\/+/g, '/').replace(/\/$/, '') + (routePath === '' ? '/' : '')
  }
  if (locale === 'ja') {
    return `/ja/${routePath}${hash}`.replace(/\/+/g, '/')
  }

  const enPath = routePath ? `/${routePath}${hash}` : `/${hash}`
  return enPath.replace(/\/+/g, '/')
}

function convertMdLinks(content, filePath, locale) {
  const fileDir = path.dirname(filePath)
  return content.replace(/\[([^\]]*)\]\(([^)]+)\)/g, (full, text, link) => {
    const converted = resolveMdLink(link.trim(), fileDir, locale)
    return `[${text}](${converted})`
  })
}

function addLanguagesTip(content, locale, fileName) {
  if (fileName === 'index.md') return content

  const tips = {
    en: '::: tip Languages\nThis page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).\n:::\n\n',
    'zh-cn':
      '::: tip 语言 / Languages\n本页另有 [English](/) 和 [日本語](/ja/) 版本。\n:::\n\n',
    ja: '::: tip 言語 / Languages\nこのページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。\n:::\n\n',
  }

  const tip = tips[locale]
  if (!tip || content.includes('::: tip Languages') || content.includes('::: tip 语言') || content.includes('::: tip 言語')) {
    return content
  }

  const fmEnd = content.match(/^---\n[\s\S]*?\n---\n/)
  if (fmEnd) {
    return content.slice(0, fmEnd[0].length) + tip + content.slice(fmEnd[0].length)
  }
  return tip + content
}

function walk(dir, files = []) {
  for (const entry of fs.readdirSync(dir, { withFileTypes: true })) {
    const full = path.join(dir, entry.name)
    if (entry.isDirectory()) walk(full, files)
    else if (entry.name.endsWith('.md')) files.push(full)
  }
  return files
}

function simplifyLinks(content) {
  // Fix common patterns after first pass
  return content
    .replace(/\]\(\.\)/g, '](/')
    .replace(/\]\(zh-cn\/\)/g, '](/zh-cn/)')
    .replace(/\]\(ja\/\)/g, '](/ja/)')
    .replace(/\]\(\/index\)/g, '](/)')
    .replace(/\]\(\/zh-cn\/index\)/g, '](/zh-cn/)')
    .replace(/\]\(\/ja\/index\)/g, '](/ja/)')
    .replace(/(\/[^)\s]+)\/+\)/g, '$1)')
}

const homeLayouts = {
  en: `---
layout: home
title: Overview
description: Compile-time MVVM for Prism — MvvmAIO.Prism.SourceGenerators documentation.

hero:
  name: Prism.SourceGenerators
  text: Compile-time MVVM for Prism
  tagline: MvvmAIO.Prism.SourceGenerators removes boilerplate for observable properties, commands, and container registration while preserving BindableBase semantics.
  actions:
    - theme: brand
      text: Getting started
      link: /getting-started
    - theme: alt
      text: Generators
      link: /generators/
    - theme: alt
      text: Diagnostics
      link: /diagnostics/reference

features:
  - title: Observable
    details: "[ObservableProperty] for fields and C# 13+ partial properties, with OnChanging / OnChanged hooks and [NotifyPropertyChangedFor]."
  - title: Commands
    details: "[DelegateCommand] and [AsyncDelegateCommand] from methods, including ValueTask support."
  - title: Registration
    details: Attributes such as [RegisterForNavigation] and [RegisterSingleton] emit IContainerRegistry registration code.
  - title: Diagnostics
    details: PSG diagnostics with code fixes (for example MakePartial) where the generator can guide you.
---

::: tip Canonical documentation
**This site** is the **authoritative manual** for the project—deeper and more structured than the GitHub **README**, **GitHub Wiki**, or exploratory mirrors such as DeepWiki. Start with **[About this site](/about-this-site)** for how those surfaces relate.
:::

::: info Languages / 语言 / 言語
This site is available in **[English](/)**, **[简体中文](/zh-cn/)**, and **[日本語](/ja/)**.
:::

## Where to read next

| Page | Purpose |
|------|---------|
| [Getting started](/getting-started) | Install packages, partial types, Prism 8 vs 9. |
| [Generators](/generators/) | Topic-by-topic generator reference. |
| [Diagnostics reference](/diagnostics/reference) | Every **PSG** ID in one table. |
| [Architecture](/architecture/overview) | Repos, layout, Roslyn multi-targeting. |
| [Build & CI](/build-and-ci) | slnx, Nuke, pipelines. |
| [Samples](/samples) | **Prism.SourceGenerators.Samples** (Avalonia, Prism 8/9). |

## Repository layout

- \`Prism.SourceGenerators/\` — shared generator logic (\`.shproj\` / \`.projitems\`).
- \`Prism.SourceGenerators.Core/\` — attributes consumed by your app and seen by the generator.
- \`Prism.SourceGenerators.Roslyn*\` — version-specific compiler targets for NuGet compatibility.
- \`Prism.Bcl.Commands/\` — optional Prism 8 \`AsyncDelegateCommand\` compatibility package.
- Sample Avalonia apps live in the separate **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** repository.

## NuGet packages

| Package | Role |
|---------|------|
| [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators) | Core source generator: \`ObservableProperty\`, command generation, container registration. |
| [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands) | Compatibility package for Prism 8 \`AsyncDelegateCommand\` scenarios. |

![NuGet downloads](https://img.shields.io/nuget/dt/MvvmAIO.Prism.SourceGenerators?logo=nuget)
![NuGet downloads BCL](https://img.shields.io/nuget/dt/MvvmAIO.Prism.Bcl.Commands?logo=nuget)

## Also useful (non-canonical)

- **[GitHub repository](https://github.com/MvvmAIO/Prism.SourceGenerators)** — issues, PRs, CI.
- **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** — exploratory outline; may lag or diverge from this site.
`,
  'zh-cn/index.md': `---
layout: home
title: 概览
description: 面向 Prism 的编译期 MVVM — MvvmAIO.Prism.SourceGenerators 文档。

hero:
  name: Prism.SourceGenerators
  text: Prism 的编译期 MVVM
  tagline: MvvmAIO.Prism.SourceGenerators 在保留 BindableBase 语义的前提下，为可观察属性、命令与容器注册消除样板代码。
  actions:
    - theme: brand
      text: 快速开始
      link: /zh-cn/getting-started
    - theme: alt
      text: 源生成器
      link: /zh-cn/generators/
    - theme: alt
      text: 诊断
      link: /zh-cn/diagnostics/reference

features:
  - title: Observable
    details: 字段与 C# 13+ partial property 的 [ObservableProperty]，含 OnChanging / OnChanged 与 [NotifyPropertyChangedFor]。
  - title: Commands
    details: 从方法生成 [DelegateCommand] 与 [AsyncDelegateCommand]，包含 ValueTask 等异步形态。
  - title: Registration
    details: "[RegisterForNavigation]、[RegisterSingleton] 等特性生成 IContainerRegistry 注册代码。"
  - title: Diagnostics
    details: PSG 诊断与代码修复（例如 MakePartial）。
---

::: tip 权威文档
**本站**是项目的**权威手册**，比 GitHub **README**、**GitHub Wiki** 或 DeepWiki 等更完整、更可交叉检索。请先阅读 **[关于本站](/zh-cn/about-this-site)** 了解与各渠道的分工。
:::

::: info 语言 / Languages
本站提供 **[English](/)**、**[简体中文](/zh-cn/)** 与 **[日本語](/ja/)**。
:::

## 接下来读什么

| 页面 | 说明 |
|------|------|
| [快速开始](/zh-cn/getting-started) | 安装、partial、Prism 8/9。 |
| [源生成器总览](/zh-cn/generators/) | 按主题的生成器说明（简体中文正文）。 |
| [诊断参考](/zh-cn/diagnostics/reference) | **PSG** 全表。 |
| [架构总览](/zh-cn/architecture/overview) | 仓库与多 Roslyn 目标。 |
| [构建与 CI](/zh-cn/build-and-ci) | slnx、Nuke、流水线。 |
| [示例](/zh-cn/samples) | **Prism.SourceGenerators.Samples**。 |

## 仓库结构

- \`Prism.SourceGenerators/\` — 共享生成器逻辑（\`.shproj\` / \`.projitems\`）。
- \`Prism.SourceGenerators.Core/\` — 应用引用的特性程序集。
- \`Prism.SourceGenerators.Roslyn*\` — 针对不同 Roslyn 版本的编译目标。
- \`Prism.Bcl.Commands/\` — 可选 Prism 8 \`AsyncDelegateCommand\` 兼容包。
- Avalonia 示例见 **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)**。

## NuGet 包

| 包 | 说明 |
|----|------|
| [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators) | 核心源生成器。 |
| [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands) | Prism 8 场景下补充异步命令。 |

![NuGet](https://img.shields.io/nuget/dt/MvvmAIO.Prism.SourceGenerators?logo=nuget)

## 其他链接（非正典）

- **[GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators)** — Issue、PR、CI。
- **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** — 可浏览目录；**深度与准确性以本站为准**。
`,
  'ja/index.md': `---
layout: home
title: 概要
description: Prism 向けコンパイル時 MVVM — MvvmAIO.Prism.SourceGenerators。

hero:
  name: Prism.SourceGenerators
  text: Prism のコンパイル時 MVVM
  tagline: MvvmAIO.Prism.SourceGenerators は、BindableBase の意味論を保ちながら Observable・コマンド・コンテナ登録のボイラープレートを削減します。
  actions:
    - theme: brand
      text: はじめに
      link: /ja/getting-started
    - theme: alt
      text: ジェネレータ
      link: /ja/generators/
    - theme: alt
      text: 診断
      link: /ja/diagnostics/reference

features:
  - title: Observable
    details: フィールド／C# 13+ partial property の [ObservableProperty] など。
  - title: Commands
    details: "[DelegateCommand] / [AsyncDelegateCommand]、ValueTask 対応。"
  - title: Registration
    details: IContainerRegistry 向け登録コードの生成。
  - title: Diagnostics
    details: PSG とコードフィックス（MakePartial など）。
---

::: tip 正典ドキュメント
**このサイト**がプロジェクトの**権威あるマニュアル**です。GitHub **README**、**GitHub Wiki**、DeepWiki より深い説明と構成はここを優先してください。**[サイトについて](/ja/about-this-site)** で各チャネルの役割を説明しています。
:::

::: info 言語 / Languages
**[English](/)** · **[简体中文](/zh-cn/)** · **[日本語](/ja/)**
:::

## 次に読む

| ページ | 内容 |
|--------|------|
| [はじめに](/ja/getting-started) | インストール、partial、Prism 8/9。 |
| [ジェネレータ概要](/ja/generators/) | トピック別リファレンス（日本語本文）。 |
| [診断リファレンス](/ja/diagnostics/reference) | **PSG** 一覧。 |
| [アーキテクチャ概要](/ja/architecture/overview) | レイアウトと Roslyn マルチターゲット。 |
| [ビルドと CI](/ja/build-and-ci) | slnx、Nuke。 |
| [サンプル](/ja/samples) | **Prism.SourceGenerators.Samples**。 |

## NuGet

- [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators)
- [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands)

## その他（非正典）

- [GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators)
- [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) — 探索用。**詳細は本サイトを優先**。
`,
}

for (const file of walk(docsRoot)) {
  const rel = path.relative(docsRoot, file).replace(/\\/g, '/')
  const locale = detectLocale(file)
  const fileName = path.basename(file)

  if (homeLayouts[rel]) {
    fs.writeFileSync(file, homeLayouts[rel], 'utf-8')
    console.log('Home layout:', rel)
    continue
  }

  let content = fs.readFileSync(file, 'utf-8')
  content = convertAdmonitions(content)
  content = convertMdLinks(content, file, locale)
  content = simplifyLinks(content)
  content = addLanguagesTip(content, locale, fileName)

  // Remove NuStreamDocs footer line
  content = content.replace(
    /_This documentation site is built with \[\.NET 10\][\s\S]*?NuStreamDocs\)[\s\S]*?\._\n?/g,
    '',
  )

  // Remove old Documentation updates section (SiteFooter handles on home)
  content = content.replace(
    /\n## Documentation updates\n\n[\s\S]*?(?=\n## |\n---|\n*$)/,
    '\n',
  )

  fs.writeFileSync(file, content, 'utf-8')
  console.log('Migrated:', rel)
}

console.log('Done.')
