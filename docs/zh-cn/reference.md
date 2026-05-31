---
title: 参考与链接
description: 外部资源、本站内导航与生成器仓库常用命令。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# 参考与链接

将下列资源与侧栏正文配合使用。**语义、诊断与架构**请以本站页面为准，第三方镜像仅作辅助。

::: info 语言
[English](/zh-cn/reference) · [日本語](/ja/reference)

:::
---

## 快速链接

| 资源 | 说明 |
|------|------|
| **[Prism.SourceGenerators（GitHub）](https://github.com/MvvmAIO/Prism.SourceGenerators)** | 源码、议题、PR、CI。 |
| **[GitHub Wiki](https://github.com/MvvmAIO/Prism.SourceGenerators/wiki)**（[`wiki/` 目录](https://github.com/MvvmAIO/Prism.SourceGenerators/tree/master/wiki)） | 简要中文笔记；**权威内容以本站为准**。 |
| **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** | 本站仓库（Markdown、VitePress、发布工作流）。 |
| **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | Avalonia 可运行示例（Prism 8 / 9）。 |
| **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** | 仓库的 AI 索引，便于浏览；**不作为行为或诊断文案的合同**。 |

---

## 本站内导航

| 主题 | 页面 |
|------|------|
| 源生成器 | [总览](/zh-cn/generators/) |
| **PSG** 诊断 | [诊断参考](/zh-cn/diagnostics/reference) |
| 本地构建与 CI | [构建与 CI](/zh-cn/build-and-ci) |
| 产品与文档贡献 | [贡献指南](/zh-cn/contributing) |
| Avalonia 可运行示例 | [示例](/zh-cn/samples) |

---

## 生成器仓库目录结构

```
Prism.SourceGenerators/
Prism.SourceGenerators.Roslyn4001/
Prism.SourceGenerators.Roslyn4031/
Prism.SourceGenerators.Roslyn4120/
Prism.SourceGenerators.Roslyn5000/
Prism.SourceGenerators.Core/
Prism.Bcl.Commands/
```

---

## Build 与 Nuke

在 **Prism.SourceGenerators** 仓库根目录：

```bash
dotnet build Prism.SourceGenerators.slnx
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

---

## CI 与质量信号

- **`.NET`** 工作流徽章反映 **`master`** 流水线状态。
- **`Tests`** 徽章展示通过 / 失败 / 跳过数量。
- 工作流上传 **`.trx`** 测试产物。

---

## README、Wiki 与本站

主仓库 **README**（多语言）与 **GitHub Wiki** 为**简要入口**；**表格、交叉链接与多语言长文**由本站维护，角色说明见 **[关于本站](/zh-cn/about-this-site)**。
