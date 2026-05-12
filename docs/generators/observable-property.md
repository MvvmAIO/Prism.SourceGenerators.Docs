---
title: ObservableProperty
description: Field and partial-property targets, PropertyAccess, and change hooks.
---

# `[ObservableProperty]`

Generates observable properties on types inheriting **`Prism.Mvvm.BindableBase`** (or compatible). The type (and property, for property targets) must be **`partial`**.

## Field target (all C# versions)

Annotate a **private field**. The generated property is **`public`** by default; use **`PropertyAccess`** to change visibility.

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

- [Notifications & forwarding](notifications.md)
- [Diagnostics: PSG0001, PSG0003](../diagnostics/reference.md)
