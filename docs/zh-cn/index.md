---
title: 概览
description: 面向 Prism 的编译期 MVVM — MvvmAIO.Prism.SourceGenerators 文档。
---

# Prism 的编译期 MVVM

**MvvmAIO.Prism.SourceGenerators** 在保留 **BindableBase** 语义的前提下，为可观察属性、命令与容器注册消除样板代码。

!!! note "语言 / Languages"
    本站提供 **[English](../)**、**[简体中文](.)** 与 **[日本語](../ja/)**。

---

## 能力一览

| 领域 | 生成器能力 |
|------|------------|
| **Observable** | 字段与 C# 13+ partial property 的 `[ObservableProperty]`，含 `OnChanging` / `OnChanged` 与 `[NotifyPropertyChangedFor]`。 |
| **Commands** | 从方法生成 `[DelegateCommand]` 与 `[AsyncDelegateCommand]`，包含 `ValueTask` 等异步形态。 |
| **Registration** | `[RegisterForNavigation]`、`[RegisterSingleton]` 等特性生成 `IContainerRegistry` 注册代码。 |
| **Diagnostics** | **PSG** 诊断与代码修复（例如 **MakePartial**）。 |

---

## 仓库结构

- `Prism.SourceGenerators/` — 共享生成器逻辑（`.shproj` / `.projitems`）。
- `Prism.SourceGenerators.Core/` — 应用引用的特性程序集。
- `Prism.SourceGenerators.Roslyn*` — 针对不同 Roslyn 版本的编译目标。
- `Prism.Bcl.Commands/` — 可选 Prism 8 `AsyncDelegateCommand` 兼容包。
- Avalonia 示例见 **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)**。

---

## NuGet 包

| 包 | 说明 |
|----|------|
| [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators) | 核心源生成器。 |
| [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands) | Prism 8 场景下补充异步命令。 |

![NuGet](https://img.shields.io/nuget/dt/MvvmAIO.Prism.SourceGenerators?logo=nuget)

---

## 延伸阅读

- **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** — 可浏览目录（架构、流水线、诊断、打包）。
- **[GitHub README](https://github.com/MvvmAIO/Prism.SourceGenerators)** — 功能列表与 API 示例的一次信息来源。

_本站使用 [.NET 10](https://dotnet.microsoft.com/) 与 **[NuStreamDocs](https://github.com/glennawatson/NuStreamDocs)** 构建。_
