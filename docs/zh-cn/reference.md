---
title: 参考与链接
---

# 外部文档

请与本站搭配使用。DeepWiki 内容可能晚于主线。

!!! note "语言"
    [English](../reference/) · [日本語](../ja/reference/)

| 资源 | 说明 |
|------|------|
| [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) | 增量流水线、打包、多 Roslyn、CI 等。 |
| [GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators) | 源码、议题、PR、CI。 |
| [Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples) | Avalonia 示例仓库。 |

## 仓库结构

```
Prism.SourceGenerators/
Prism.SourceGenerators.Roslyn4001/
Prism.SourceGenerators.Core/
Prism.Bcl.Commands/
```

## Build + Nuke

```bash
dotnet build Prism.SourceGenerators.slnx
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

## CI 与质量信号

- **`.NET`** 工作流徽章反映 **`master`** 流水线状态。
- **`Tests`** 徽章展示通过/失败/跳过数量。
- 工作流上传 **`.trx`** 诊断产物。

## 本站覆盖范围

本站概括 README / DeepWiki 主要内容；权威细节请以主仓库 **README** 为准。
