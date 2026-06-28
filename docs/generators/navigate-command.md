---
title: NavigateCommand
description: Generate DelegateCommand wrappers that call IRegionManager.RequestNavigate.
---

# NavigateCommand & NavigateOnChanged

Generate **`DelegateCommand`** members that call **`IRegionManager.RequestNavigate`**. The ViewModel must already expose an accessible **`IRegionManager`** field or property (constructor injection is typical). Generators do **not** add constructor parameters.

## NavigateCommand

```csharp
using Prism.Mvvm;
using Prism.Navigation.Regions; // Prism 9+
// using Prism.Regions;         // Prism 8 (platform assembly)
using Prism.SourceGenerators;

public partial class ShellViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;

    public ShellViewModel(IRegionManager regionManager) => _regionManager = regionManager;

    [NavigateCommand(Region = "Content", Target = "Dashboard")]
    private void GoDashboard() { }
}
```

Generates **`GoDashboardCommand`** calling `_regionManager.RequestNavigate("Content", "Dashboard")`.

Optional attribute properties: **`CommandName`**, **`RegionManagerMember`**.

## NavigateOnChanged

Apply to the same field or partial property as **`[ObservableProperty]`**:

```csharp
[ObservableProperty]
[NavigateOnChanged(Region = "Content", TargetMember = nameof(Key))]
public partial NavigationItem SelectedItem { get; set; }
```

Generates **`OnSelectedItemChanged`** that navigates when the property changes. **`TargetMember`** is evaluated on the new value (for example `Key`).

## Prism 8 vs Prism 9 regions

| Prism | `INavigationAware` / `IRegionManager` namespace |
|-------|--------------------------------------------------|
| **9+** | `Prism.Navigation.Regions` (in **Prism.Core** for `IRegionManager`; `INavigationAware` may also come from the platform package) |
| **8** | `Prism.Regions` (in **Prism.Wpf**, **Prism.Avalonia**, etc.—not in **Prism.Core** alone) |

`[NavigationAware]` picks the namespace present in the compilation. Region navigation generators use the same resolution.

## Diagnostics

| ID | When |
|----|------|
| **PSG7001** | No accessible `IRegionManager` member |
| **PSG7002** | `[NavigateCommand]` missing `Region` |
| **PSG7003** | `[NavigateCommand]` missing `Target` |
| **PSG7004** | `[NavigateOnChanged]` without `[ObservableProperty]` |
| **PSG7005** | `[NavigateOnChanged]` missing `TargetMember` |

## Related

- [NavigationAware](/generators/navigation-aware)
- [Container registration](/generators/container-registration)
