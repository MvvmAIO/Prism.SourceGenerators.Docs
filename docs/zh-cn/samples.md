---
title: 示例
description: 使用 MvvmAIO.Prism.SourceGenerators 的 Avalonia 示例应用。
---

# 示例

可运行应用位于 **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)**。

| 方面 | 说明 |
|------|------|
| **Prism 8** | 演示在需要 **`AsyncDelegateCommand`** 时使用 **`MvvmAIO.Prism.Bcl.Commands`**。 |
| **Prism 9** | 在适用场景使用 Prism 内置异步命令类型。 |
| **Avalonia** | 演示所用 UI 栈；生成器用法与 UI 框架无关。 |

克隆该仓库并在其中打开解决方案，即可端到端调试 **ObservableProperty**、**命令** 与 **注册**。

## 仓库布局

- **`Prism.SourceGenerators.Samples.slnx`** — 在 Visual Studio **17.13+** 或 Rider 中打开（需支持 `.slnx`）。
- **`Prism.SourceGenerators.Samples.Prism8`** — 目标 **`net8.0`**，Prism 8；需要 **`AsyncDelegateCommand`** 时使用 **`MvvmAIO.Prism.Bcl.Commands`**。
- **`Prism.SourceGenerators.Samples.Prism9`** — 目标 **`net10.0`**，Prism 9 与内置异步命令；含 **Validation** 示例（`BindableValidator`、`[NotifyDataErrorInfo]`、DataAnnotations）。

## 构建

需要 **.NET 10 SDK**（Prism 9 项目），并为 **`net8.0`** 准备 **.NET 8** SDK/运行时。

```bash
git clone https://github.com/MvvmAIO/Prism.SourceGenerators.Samples.git
cd Prism.SourceGenerators.Samples
dotnet build Prism.SourceGenerators.Samples.slnx
```

## 本地生成器与 NuGet

若将 **[Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** 克隆为**同级目录**（`../Prism.SourceGenerators`），**`Directory.Build.props`** 会让示例改用**项目引用**而非 **`MvvmAIO.Prism.SourceGenerators`** NuGet 包，便于开发源生成器。覆盖开关与说明见示例仓库 **`build/README-LocalSourceGenerators.md`**（`UseLocalPrismSourceGenerators`）。

## 下一步

- [快速开始](getting-started.md)
- [容器注册](generators/container-registration.md)
