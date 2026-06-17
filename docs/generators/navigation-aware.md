---
title: NavigationAware
description: Generate Prism INavigationAware members with partial hooks.
---

# NavigationAware

Apply **`[NavigationAware]`** to a **partial** class that references **`Prism.Navigation.Regions.INavigationAware`** (via Prism.Core) to emit navigation lifecycle members.

## Usage

```csharp
using Prism.Mvvm;
using Prism.Navigation.Regions;
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

## Generated members

- `OnNavigatedTo` → calls `OnNavigatedToCore`
- `IsNavigationTarget` → calls `IsNavigationTargetCore` (default `true` in generated partial)
- `OnNavigatedFrom` → calls `OnNavigatedFromCore`

## Diagnostics

| ID | When |
|----|------|
| **PSG0007** | Class is not `partial` — use the **Add partial** code fix |

## Related

- [Container registration](/generators/container-registration) — `[RegisterForNavigation]`
- [Samples](/samples)
