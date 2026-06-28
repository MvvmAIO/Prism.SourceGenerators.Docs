import path from 'node:path'
import { fileURLToPath } from 'node:url'
import { defineConfig } from 'vitepress'
import { injectHreflang } from './hreflang'
import { readSiteMeta } from './site-meta.node'

const __dirname = path.dirname(fileURLToPath(import.meta.url))
const docsRoot = path.resolve(__dirname, '../docs')
const siteBuildMeta = readSiteMeta()

const githubGenerator = 'https://github.com/MvvmAIO/Prism.SourceGenerators'
const githubDocs =
  'https://github.com/MvvmAIO/Prism.SourceGenerators.Docs'

const enSidebar = [
  { text: 'Overview', link: '/' },
  { text: 'About this site', link: '/about-this-site' },
  { text: 'Getting started', link: '/getting-started' },
  { text: 'Ecosystem positioning', link: '/positioning' },
  {
    text: 'Architecture',
    items: [
      { text: 'Overview', link: '/architecture/overview' },
      { text: 'Roslyn targeting', link: '/architecture/roslyn-targeting' },
    ],
  },
  {
    text: 'Generators',
    items: [
      { text: 'Overview', link: '/generators/' },
      { text: 'ObservableProperty', link: '/generators/observable-property' },
      { text: 'Notifications', link: '/generators/notifications' },
      { text: 'DelegateCommand', link: '/generators/delegate-command' },
      {
        text: 'AsyncDelegateCommand',
        link: '/generators/async-delegate-command',
      },
      { text: 'ObservesProperty', link: '/generators/observes-property' },
      { text: 'BindableBase', link: '/generators/bindable-base' },
      { text: 'BindableValidator', link: '/generators/bindable-validator' },
      {
        text: 'Container registration',
        link: '/generators/container-registration',
      },
      { text: 'NavigationAware', link: '/generators/navigation-aware' },
      { text: 'DialogAware', link: '/generators/dialog-aware' },
      { text: 'NavigateCommand', link: '/generators/navigate-command' },
      { text: 'ShowDialogCommand', link: '/generators/show-dialog-command' },
    ],
  },
  { text: 'Diagnostics', link: '/diagnostics/reference' },
  { text: 'Build & CI', link: '/build-and-ci' },
  { text: 'Contributing', link: '/contributing' },
  { text: 'Samples', link: '/samples' },
  { text: 'Reference & links', link: '/reference' },
]

const zhCnSidebar = [
  { text: '概览', link: '/zh-cn/' },
  { text: '关于本站', link: '/zh-cn/about-this-site' },
  { text: '快速开始', link: '/zh-cn/getting-started' },
  { text: '生态定位', link: '/zh-cn/positioning' },
  {
    text: '架构',
    items: [
      { text: '总览', link: '/zh-cn/architecture/overview' },
      { text: 'Roslyn 目标', link: '/zh-cn/architecture/roslyn-targeting' },
    ],
  },
  {
    text: '源生成器',
    items: [
      { text: '总览', link: '/zh-cn/generators/' },
      {
        text: 'ObservableProperty',
        link: '/zh-cn/generators/observable-property',
      },
      { text: '通知与转发', link: '/zh-cn/generators/notifications' },
      {
        text: 'DelegateCommand',
        link: '/zh-cn/generators/delegate-command',
      },
      {
        text: 'AsyncDelegateCommand',
        link: '/zh-cn/generators/async-delegate-command',
      },
      {
        text: 'ObservesProperty',
        link: '/zh-cn/generators/observes-property',
      },
      { text: 'BindableBase', link: '/zh-cn/generators/bindable-base' },
      {
        text: 'BindableValidator',
        link: '/zh-cn/generators/bindable-validator',
      },
      { text: '容器注册', link: '/zh-cn/generators/container-registration' },
      { text: 'NavigationAware', link: '/zh-cn/generators/navigation-aware' },
      { text: 'DialogAware', link: '/zh-cn/generators/dialog-aware' },
      { text: 'NavigateCommand', link: '/generators/navigate-command' },
      { text: 'ShowDialogCommand', link: '/generators/show-dialog-command' },
    ],
  },
  { text: '诊断', link: '/zh-cn/diagnostics/reference' },
  { text: '构建与 CI', link: '/zh-cn/build-and-ci' },
  { text: '贡献', link: '/zh-cn/contributing' },
  { text: '示例', link: '/zh-cn/samples' },
  { text: '参考与链接', link: '/zh-cn/reference' },
]

const jaSidebar = [
  { text: '概要', link: '/ja/' },
  { text: 'サイトについて', link: '/ja/about-this-site' },
  { text: 'はじめに', link: '/ja/getting-started' },
  { text: 'エコシステム', link: '/ja/positioning' },
  {
    text: 'アーキテクチャ',
    items: [
      { text: '概要', link: '/ja/architecture/overview' },
      { text: 'Roslyn ターゲット', link: '/ja/architecture/roslyn-targeting' },
    ],
  },
  {
    text: 'ソースジェネレータ',
    items: [
      { text: '概要', link: '/ja/generators/' },
      {
        text: 'ObservableProperty',
        link: '/ja/generators/observable-property',
      },
      { text: '通知', link: '/ja/generators/notifications' },
      { text: 'DelegateCommand', link: '/ja/generators/delegate-command' },
      {
        text: 'AsyncDelegateCommand',
        link: '/ja/generators/async-delegate-command',
      },
      { text: 'ObservesProperty', link: '/ja/generators/observes-property' },
      { text: 'BindableBase', link: '/ja/generators/bindable-base' },
      { text: 'BindableValidator', link: '/ja/generators/bindable-validator' },
      { text: 'コンテナ登録', link: '/ja/generators/container-registration' },
      { text: 'NavigationAware', link: '/ja/generators/navigation-aware' },
      { text: 'DialogAware', link: '/ja/generators/dialog-aware' },
      { text: 'NavigateCommand', link: '/generators/navigate-command' },
      { text: 'ShowDialogCommand', link: '/generators/show-dialog-command' },
    ],
  },
  { text: '診断', link: '/ja/diagnostics/reference' },
  { text: 'ビルドと CI', link: '/ja/build-and-ci' },
  { text: 'コントリビュート', link: '/ja/contributing' },
  { text: 'サンプル', link: '/ja/samples' },
  { text: '参考・リンク', link: '/ja/reference' },
]

export default defineConfig({
  srcDir: 'docs',
  vite: {
    define: {
      __SITE_META__: JSON.stringify(siteBuildMeta),
    },
  },
  title: 'Prism.SourceGenerators',
  description:
    'Compile-time MVVM for Prism — MvvmAIO.Prism.SourceGenerators documentation',
  base: '/Prism.SourceGenerators.Docs/',
  sitemap: {
    hostname: 'https://mvvmaio.github.io/Prism.SourceGenerators.Docs/',
  },
  cleanUrls: true,
  lastUpdated: {
    formatOptions: {
      dateStyle: 'medium',
      timeStyle: 'short',
      timeZoneName: 'short',
    },
  },
  head: [
    [
      'link',
      {
        rel: 'icon',
        href: '/Prism.SourceGenerators.Docs/favicon.svg',
        type: 'image/svg+xml',
      },
    ],
    ['meta', { property: 'og:type', content: 'website' }],
    ['meta', { property: 'og:site_name', content: 'Prism.SourceGenerators' }],
    ['meta', { name: 'twitter:card', content: 'summary' }],
  ],
  transformPageData(pageData) {
    const title =
      pageData.frontmatter.title ??
      pageData.title ??
      'Prism.SourceGenerators'
    const description =
      pageData.frontmatter.description ??
      pageData.description ??
      'Compile-time MVVM for Prism — MvvmAIO.Prism.SourceGenerators documentation'
    pageData.frontmatter.head ??= []
    pageData.frontmatter.head.push(
      ['meta', { property: 'og:title', content: title }],
      ['meta', { property: 'og:description', content: description }],
      ['meta', { name: 'twitter:title', content: title }],
      ['meta', { name: 'twitter:description', content: description }],
    )
    injectHreflang(pageData, docsRoot)
  },
  themeConfig: {
    logo: { text: 'Prism.SourceGenerators' },
    socialLinks: [{ icon: 'github', link: githubGenerator }],
    search: { provider: 'local' },
    footer: {
      message: 'Released under the MIT License.',
      copyright: 'Copyright © MvvmAIO',
    },
  },
  locales: {
    root: {
      label: 'English',
      lang: 'en',
      themeConfig: {
        nav: [
          { text: 'Guide', link: '/getting-started' },
          { text: 'Generators', link: '/generators/' },
          { text: 'Diagnostics', link: '/diagnostics/reference' },
          { text: 'Samples', link: '/samples' },
        ],
        sidebar: enSidebar,
        editLink: {
          pattern: `${githubDocs}/edit/main/docs/:path`,
          text: 'Edit this page on GitHub',
        },
        lastUpdatedText: 'Last updated',
      },
    },
    'zh-cn': {
      label: '简体中文',
      lang: 'zh-Hans',
      link: '/zh-cn/',
      themeConfig: {
        nav: [
          { text: '指南', link: '/zh-cn/getting-started' },
          { text: '源生成器', link: '/zh-cn/generators/' },
          { text: '诊断', link: '/zh-cn/diagnostics/reference' },
          { text: '示例', link: '/zh-cn/samples' },
        ],
        sidebar: zhCnSidebar,
        editLink: {
          pattern: `${githubDocs}/edit/main/docs/:path`,
          text: '在 GitHub 上编辑此页',
        },
        footer: {
          message: '基于 MIT 许可证发布。',
          copyright: 'Copyright © MvvmAIO',
        },
        lastUpdatedText: '页面最后更新于',
      },
    },
    ja: {
      label: '日本語',
      lang: 'ja',
      link: '/ja/',
      themeConfig: {
        nav: [
          { text: 'はじめに', link: '/ja/getting-started' },
          { text: 'ジェネレータ', link: '/ja/generators/' },
          { text: '診断', link: '/ja/diagnostics/reference' },
          { text: 'サンプル', link: '/ja/samples' },
        ],
        sidebar: jaSidebar,
        editLink: {
          pattern: `${githubDocs}/edit/main/docs/:path`,
          text: 'GitHub でこのページを編集',
        },
        footer: {
          message: 'MIT ライセンスの下で公開されています。',
          copyright: 'Copyright © MvvmAIO',
        },
        lastUpdatedText: '最終更新',
      },
    },
  },
})
