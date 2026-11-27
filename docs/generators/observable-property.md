---
title: ObservableProperty
description: Field and partial-property targets, PropertyAccess, and change hooks.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# `[ObservableProperty]`

Generates observable properties on types inheriting **`Prism.Mvvm.BindableBase`** (or compatible). The type (and property, for property targets) must be **`partial`**.

## Field target

Annotate a **private field**. The generated property is **`public`** by default; use **`PropertyAccess`** to change visibility.

With version 0.8.1, projects targeting .NET Framework 4.8 with C# 7.3 can get CS8370 in generated code. Setting `LangVersion` to `8.0` works around this without changing the target framework. The fix for [#117](https://github.com/MvvmAIO/Prism.SourceGenerators/issues/117) lets the same field and command example compile with C# 7.3.

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    private string _title = "Hello";

    [ObservableProperty(PropertyAccess.Internal)]
    private int _count;
}
```

The setter uses **`EqualityComparer<T>.Default`** for early-out, then **`SetProperty`** so **`BindableBase`** semantics (including overrides) apply. **`[NotifyPropertyChangedFor]`** and **`[NotifyCanExecuteChangedFor]`** run after that path.

## Partial property target (C# 13+, `field` keyword)

Annotate a **`partial`** property; the generator emits the **`field`**-backed implementation.

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    public partial string Title { get; set; } = "Hello";
}
```

Accessibility comes from the property declaration; **`PropertyAccess`** is ignored for this mode.

## `OnChanging` / `OnChanged` hooks

The generator declares **`partial`** methods you can implement—for example **`OnAgeChanging`**, **`OnAgeChanged`**—invoked **before** and **after** the storage update (see product README for exact overload pairs).

## Related

- [Notifications & forwarding](/generators/notifications)
- [Diagnostics: PSG0001, PSG0003](/diagnostics/reference)
