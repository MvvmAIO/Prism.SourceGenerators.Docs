---
title: 架构总览
description: 多仓库、共享生成器工程与主要生成入口。
---

# 架构总览

## 仓库

| 仓库 | 作用 |
|------|------|
| **[Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** | 源生成器、**MvvmAIO.Prism.Core** 特性、打包、测试、CI。 |
| **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** | 本站静态文档（NuStreamDocs）。 |
| **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | Avalonia 示例（Prism 8 / 9）。 |

## Prism.SourceGenerators 仓库内布局

```
Prism.SourceGenerators/           # 共享实现（.shproj / .projitems）
Prism.SourceGenerators.Core/    # 作为 MvvmAIO.Prism.Core 分发的特性（应用与分析器均引用）
Prism.SourceGenerators.Roslyn*/ # 按编译器版本拆分的生成器工程（NuGet 兼容）
Prism.Bcl.Commands/             # 可选：Prism 8 下 AsyncDelegateCommand 兼容包
```

**共享**工程承载大部分生成逻辑。**Roslyn\*** 各工程引用与其 NuGet 发行线所期望的 **Roslyn 版本**；构建会选出与消费者工具链匹配的程序集。

## 主要生成器（概念划分）

| 领域 | 职责 |
|------|------|
| **Observable / 命令** | `[ObservableProperty]`、`[DelegateCommand]`、`[AsyncDelegateCommand]` 及相关特性。 |
| **容器** | 注册类特性 → `PrismRegistrationExtensions.g.cs` → 对 `IContainerRegistry` 的调用。 |
| **BindableBase** | `[BindableBase]`：为未继承 Prism `BindableBase` 的类型生成 **INPC** 辅助代码。 |

各管线使用 **Roslyn 增量生成**（`IIncrementalGenerator`），并在可行处使用 **较窄的特性提供器**，以降低重复编译成本。

## 下一步

- [Roslyn 目标与包](roslyn-targeting.md)
- [构建与 CI](../build-and-ci.md)
