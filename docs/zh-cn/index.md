---
title: 概览
description: 面向 Prism 的编译期 MVVM — MvvmAIO.Prism.SourceGenerators 文档。
---

# Prism 的编译期 MVVM

**MvvmAIO.Prism.SourceGenerators** 在保留 **BindableBase** 语义的前提下，为可观察属性、命令与容器注册消除样板代码。

!!! success "权威文档"
    **本站**是项目的**权威手册**，比 GitHub **README**、**GitHub Wiki** 或 DeepWiki 等更完整、更可交叉检索。请先阅读 **[关于本站](about-this-site.md)** 了解与各渠道的分工。

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

## 接下来读什么

| 页面 | 说明 |
|------|------|
| [快速开始](getting-started.md) | 安装、partial、Prism 8/9。 |
| [源生成器总览](generators/index.md) | 按主题的生成器说明（简体中文正文）。 |
| [诊断参考](diagnostics/reference.md) | **PSG** 全表。 |
| [架构总览](architecture/overview.md) | 仓库与多 Roslyn 目标。 |
| [构建与 CI](build-and-ci.md) | `slnx`、Nuke、流水线。 |
| [示例](samples.md) | **Prism.SourceGenerators.Samples**。 |

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

## 其他链接（非正典）

- **[GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators)** — Issue、PR、CI。
- **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** — 可浏览目录；**深度与准确性以本站为准**。

_本站使用 [.NET 10](https://dotnet.microsoft.com/) 与 **[NuStreamDocs](https://github.com/glennawatson/NuStreamDocs)** 构建。_
