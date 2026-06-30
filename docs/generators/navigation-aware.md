---
title: NavigationAware
description: Generate Prism INavigationAware members with partial hooks.
---

# NavigationAware

Apply **`[NavigationAware]`** to a **partial** class to emit **`INavigationAware`** members and optional **`OnNavigatedToCore`** / **`IsNavigationTargetCore`** / **`OnNavigatedFromCore`** hooks.

The generator runs when the compilation references a regions API:

| Prism | Namespace |
|-------|-----------|
| **9+** | `Prism.Navigation.Regions` |
| **8** | `Prism.Regions` (from **Prism.Wpf**, **Prism.Avalonia**, etc.) |

## Usage

```csharp
using Prism.Mvvm;
using Prism.Navigation.Regions; // or Prism.Regions on Prism 8
using Prism.SourceGenerators;

[NavigationAware]
public partial class DashboardViewModel : BindableBase
{
    partial void OnNavigatedToCore(NavigationContext navigationContext)
    {
        // Called when the view enters the region.
    }
}
```

Override navigation reuse with **`private partial bool IsNavigationTargetCore(...)`** when the default `true` is not enough.

## Generated members

- `OnNavigatedTo` → calls `OnNavigatedToCore`
- `IsNavigationTarget` → calls `IsNavigationTargetCore` (default `true` in generated partial)
- `OnNavigatedFrom` → calls `OnNavigatedFromCore`

## `[FromNavigationParameter]`

Apply **`[FromNavigationParameter]`** to an `[ObservableProperty]` field or partial property to read a typed value from `NavigationContext.Parameters` via `TryGetValue<T>` and assign it through the property setter before `OnNavigatedToCore` is invoked.

```csharp
[NavigationAware]
public partial class DashboardViewModel : BindableBase
{
    [FromNavigationParameter("userId")]
    [ObservableProperty]
    public partial int UserId { get; set; }

    [FromNavigationParameter]  // key defaults to "UserName"
    [ObservableProperty]
    public partial string UserName { get; set; }
}
```

If the parameter is absent, the property retains its initial value. The key defaults to the property name when not specified.

## Diagnostics

| ID | When |
|----|------|
| **PSG0007** | Class is not `partial` — use the **Add partial** code fix |
| **PSG7006** | Attribute applied to a non-field/property member |
| **PSG7007** | Member lacks `[ObservableProperty]` |
| **PSG7008** | Key is empty |

## Related

- [NavigateCommand](/generators/navigate-command)
- [Container registration](/generators/container-registration) — `[RegisterForNavigation]`
- [Samples](/samples)
