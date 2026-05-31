---
title: Roslyn 目标与 NuGet 包
description: 为何存在多个 Roslyn* 工程，以及应用应引用哪些包。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# Roslyn 目标与包

## 为何有多个 `Prism.SourceGenerators.Roslyn*` 工程？

Roslyn 的 **公共 API** 与 **语言特性** 随编译器主版本演进。产品会发布 **多个生成器程序集**，各自针对特定 Roslyn 版本编译，以便 NuGet 交付与 **最低编译器** 期望一致的包。

下表为典型对应关系（**名称仅作示意**——请以 **`master`** 上仓库实际目录为准）：

| 工程目录 | 意图 |
|----------|------|
| `Roslyn4001` | 仍停留在 Roslyn 4.0.x 的旧版 VS / SDK。 |
| `Roslyn4031` | 4.x 中期线路。 |
| `Roslyn4120` | 较新的 4.12 时代 API。 |
| `Roslyn5000` | Roslyn 5 / 当前 C# 能力前沿。 |

**应用项目不要直接引用这些工程。** **MvvmAIO.Prism.SourceGenerators** 包内已包含与所声明 SDK 支持范围匹配的预编译生成器。

## 应用中应引用的包

- **`MvvmAIO.Prism.SourceGenerators`** — 分析器 + 生成器 + **MvvmAIO.Prism.Core**（特性）。
- **`MvvmAIO.Prism.Bcl.Commands`** — 在 **Prism.Core 8.1.97** 上若需要 **`AsyncDelegateCommand`** 则可选；见 [诊断参考](/zh-cn/diagnostics/reference) 中的 **PSG3002** 与 [AsyncDelegateCommand](/zh-cn/generators/async-delegate-command)。

## 下一步

- [架构总览](/zh-cn/architecture/overview)
- [快速开始](/zh-cn/getting-started)
