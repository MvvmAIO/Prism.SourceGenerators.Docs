---
title: 快速开始
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# 安装与引用

在基于 **BindableBase**（或兼容基类）的 Prism 应用中添加 NuGet 包。生成器要求处请使用 **partial** 类型。

::: info 语言
[English](/getting-started) · [日本語](/ja/getting-started)

:::
## 1. 添加包

```bash
dotnet add package MvvmAIO.Prism.SourceGenerators
```

## 2. 使用 partial 类型

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    private string _title = "";
}
```

出现 **PSG0001–PSG0004** 时可使用 **MakePartial** 等代码修复。

## 3. Prism 8 与 9

在 **Prism.Core 8.1.97** 上若需 `AsyncDelegateCommand`，可能还要安装 **MvvmAIO.Prism.Bcl.Commands**。**Prism 9** 已内置异步命令。

```bash
dotnet add package MvvmAIO.Prism.Bcl.Commands
```

## 4. 运行示例

克隆 **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)**，然后构建 **`Prism.SourceGenerators.Samples.slnx`**。仓库布局、Validation 示例以及生成器 **本地引用与 NuGet** 的切换说明见 **[示例](/zh-cn/samples)**。

## 环境要求

- **.NET 10 SDK**
- **Visual Studio 2022 17.13+** / Rider / VS Code with C# Dev Kit（支持 `.slnx`）
- 使用 **`BindableBase`**（或兼容基类）的 Prism 应用

## 推荐包组合

```xml
<ItemGroup>
  <PackageReference Include="MvvmAIO.Prism.SourceGenerators" Version="0.5.0" />
  <PackageReference Include="MvvmAIO.Prism.Bcl.Commands" Version="0.5.0" />
</ItemGroup>
```

## 构建与验证

```bash
dotnet build Prism.SourceGenerators.slnx
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

## 常见升级说明

- **C# 13+** 支持使用 `field` 的 partial-property `[ObservableProperty]`。
- **C# 14+** 命令生成可直接使用 `field`。
- **`ValueTask` / `ValueTask<T>`** 通过 `.AsTask()` 接入异步命令生成。
- 缺少异步命令符号时会报告 **PSG3002**。
