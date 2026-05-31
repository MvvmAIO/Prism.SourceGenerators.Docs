---
title: 容器注册
description: 发出 IContainerRegistry 注册调用的特性。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# 容器注册

**`ContainerRegistryRegistrationGenerator`** 收集注册类特性，并生成 **`PrismRegistrationExtensions.g.cs`**，其中扩展方法调用与 **Prism 8** 及 **Prism 9+** 兼容的 **`IContainerRegistry`** API。

## 应用中的调用点

你仍须在组合根（例如 **`RegisterTypes`**）中调用生成的扩展，并传入 **`IContainerRegistry`**。生成代码中的**确切方法名**以生成为准——成功构建后在 **obj** 输出中打开 **`PrismRegistrationExtensions.g.cs`** 核对；或与示例对比。

::: info 示例
**[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** 包含 Avalonia + Prism 8/9 的可用注册示例。

:::

## 特性（摘要）

| 特性 | 用途 |
|------|------|
| **`[Register]`**、**`[Register<T>]`** | 一般注册，**`PrismRegistrationLifetime`**（Transient / Scoped / Singleton）。 |
| **`[RegisterSingleton]`**、**`[RegisterSingleton<T>]`** | 单例便捷写法。 |
| **`[RegisterScoped]`**、**`[RegisterScoped<T>]`** | 作用域生命周期。 |
| **`[RegisterTransient]`**、**`[RegisterTransient<T>]`** | 瞬态生命周期。 |
| **`[RegisterForNavigation]`**、**`[RegisterForNavigation<TViewModel>]`** | **`RegisterForNavigation<TView, TViewModel>(name)`**。 |
| **`[RegisterDialog]`**、**`[RegisterDialog<TViewModel>]`** | 带 **`ViewModelType`** 的对话框注册。 |
| **`[RegisterDialogWindow]`** | 对话框窗口注册。 |

常见属性：**`Name`**、**`ServiceType`**、**`IfNotRegistered`**、**`ViewModelType`**（在需要处）。

## 生成顺序（确定性）

导航类注册排在**对话框之前**，再按生命周期类注册排序，保证各次构建输出顺序稳定。

## 诊断

| ID | 情形 |
|----|------|
| **PSG4001** | **`ServiceType`** 与实现类型不可赋值。 |
| **PSG4002** | 导航/对话框特性上的 **`ViewModelType`** 无法解析；跳过该注册。 |

## 示例（导航）

```csharp
namespace Demo;

public sealed partial class MyVm { }

[Prism.SourceGenerators.RegisterForNavigation(ViewModelType = typeof(Demo.MyVm), Name = "mine")]
public sealed partial class MyView { }
```

会生成 **`RegisterForNavigation<MyView, MyVm>("mine")`** 风格调用（确切形式以产品测试为准）。

## 相关

- [架构总览](/zh-cn/architecture/overview)
- [诊断参考](/zh-cn/diagnostics/reference)
