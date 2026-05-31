---
title: Container registration
description: Attributes that emit IContainerRegistry registration calls.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# Container registration

**`ContainerRegistryRegistrationGenerator`** collects registration attributes and emits **`PrismRegistrationExtensions.g.cs`** with an extension method that calls **`IContainerRegistry`** APIs compatible with **Prism 8** and **Prism 9+**.

## Call site in your app

You still invoke the generated extension from your composition root (for example **`RegisterTypes`**), passing **`IContainerRegistry`**. The exact method name is defined in generated code—open **`PrismRegistrationExtensions.g.cs`** in your **obj** output after a successful build if your template differs from the samples.

::: info Samples
**[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** shows working registration for Avalonia + Prism 8/9.

:::
## Attributes (summary)

| Attribute | Purpose |
|-----------|---------|
| **`[Register]`**, **`[Register<T>]`** | General registration with **`PrismRegistrationLifetime`** (Transient / Scoped / Singleton). |
| **`[RegisterSingleton]`**, **`[RegisterSingleton<T>]`** | Singleton lifetime convenience. |
| **`[RegisterScoped]`**, **`[RegisterScoped<T>]`** | Scoped lifetime. |
| **`[RegisterTransient]`**, **`[RegisterTransient<T>]`** | Transient lifetime. |
| **`[RegisterForNavigation]`**, **`[RegisterForNavigation<TViewModel>]`** | **`RegisterForNavigation<TView, TViewModel>(name)`**. |
| **`[RegisterDialog]`**, **`[RegisterDialog<TViewModel>]`** | Dialog registration with **`ViewModelType`**. |
| **`[RegisterDialogWindow]`** | Dialog window registration. |

Common properties: **`Name`**, **`ServiceType`**, **`IfNotRegistered`**, **`ViewModelType`** (where required).

## Emission order (deterministic)

Navigation registrations are sorted **before** dialogs, then lifetime-based registrations, so output order is stable across builds.

## Diagnostics

| ID | When |
|----|------|
| **PSG4001** | **`ServiceType`** is not assignable from the implementation type. |
| **PSG4002** | **`ViewModelType`** on navigation/dialog attributes could not be resolved; registration is skipped. |

## Example (navigation)

```csharp
namespace Demo;

public sealed partial class MyVm { }

[Prism.SourceGenerators.RegisterForNavigation(ViewModelType = typeof(Demo.MyVm), Name = "mine")]
public sealed partial class MyView { }
```

Emits a **`RegisterForNavigation<MyView, MyVm>("mine")`** style call (see product tests for exact emitted form).

## Related

- [Architecture overview](/architecture/overview)
- [Diagnostics reference](/diagnostics/reference)
