---
title: ObservableProperty
description: 字段与 partial 属性目标、PropertyAccess 与变更钩子。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# `[ObservableProperty]`

为继承 **`Prism.Mvvm.BindableBase`**（或兼容基类）的类型生成可观察属性。类型（以及属性目标下的属性）必须为 **`partial`**。

## 字段目标（各 C# 版本）

标注 **private 字段**。生成属性默认 **`public`**；用 **`PropertyAccess`** 可调整可见性。

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    private string _title = "Hello";

    [ObservableProperty(PropertyAccess.Internal)]
    private int _count;
}
```

setter 使用 **`EqualityComparer<T>.Default`** 做短路比较，再调用 **`SetProperty`**，从而保留 **`BindableBase`** 语义（含重写）。**`[NotifyPropertyChangedFor]`** 与 **`[NotifyCanExecuteChangedFor]`** 在该路径之后执行。

## Partial 属性目标（C# 13+、`field` 关键字）

标注 **`partial`** 属性；生成器发出基于 **`field`** 的实现。

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    public partial string Title { get; set; } = "Hello";
}
```

可见性由属性声明决定；此模式下忽略 **`PropertyAccess`**。

## `OnChanging` / `OnChanged` 钩子

生成器声明你可实现的 **`partial`** 方法（例如 **`OnAgeChanging`**、**`OnAgeChanged`**），在存储更新**前后**调用（精确重载组合见产品 README）。

## 相关

- [通知与转发](/zh-cn/generators/notifications)
- [诊断：PSG0001、PSG0003](/zh-cn/diagnostics/reference)
