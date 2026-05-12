---
title: 参考与链接
description: 外部资源、本站内导航与生成器仓库常用命令。
---

# 参考与链接

将下列资源与侧栏正文配合使用。**语义、诊断与架构**请以本站页面为准，第三方镜像仅作辅助。

!!! note "语言"
    [English](../reference.md) · [日本語](../ja/reference.md)

---

## 快速链接

| 资源 | 说明 |
|------|------|
| **[Prism.SourceGenerators（GitHub）](https://github.com/MvvmAIO/Prism.SourceGenerators)** | 源码、议题、PR、CI。 |
| **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** | 本站仓库（Markdown、`mkdocs.yml`、发布工作流）。 |
| **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | Avalonia 可运行示例（Prism 8 / 9）。 |
| **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** | 仓库的 AI 索引，便于浏览；**不作为行为或诊断文案的合同**。 |

---

## 本站内导航

| 主题 | 页面 |
|------|------|
| 源生成器 | [总览](generators/index.md) |
| **PSG** 诊断 | [诊断参考](diagnostics/reference.md) |
| 本地构建与 CI | [构建与 CI](build-and-ci.md) |
| 产品与文档贡献 | [贡献指南](contributing.md) |

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

## README 与本站

GitHub **README** 适合短平快入门；**表格、交叉链接与多语言长文**由本站维护，变更在 **Prism.SourceGenerators.Docs** 中审阅，无需与每次产品发布强绑定。
