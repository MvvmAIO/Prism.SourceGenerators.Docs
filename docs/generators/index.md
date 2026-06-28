---
title: Generators
description: Index of source generator features for Prism MVVM.
---

::: tip Languages
This page is also available in [简体中文](/zh-cn/generators/) and [日本語](/ja/generators/).
:::

# Generators

MvvmAIO.Prism.SourceGenerators extends **partial** types at compile time. Attributes live in **`MvvmAIO.Prism.Core`** (namespace **`Prism.SourceGenerators`**).

::: tip Partial types
**`partial`** is required wherever generated members merge into your declaration. **PSG0001–PSG0005** cover the common mistakes; all five have a **MakePartial** code fix in the IDE.

:::

## Topics

| Topic | Summary |
|-------|---------|
| [ObservableProperty](/generators/observable-property) | Field and **C# 13+** partial-property targets, **`PropertyAccess`**, **`OnChanging` / `OnChanged`**. |
| [Notifications & forwarding](/generators/notifications) | **`[NotifyPropertyChangedFor]`**, **`[NotifyCanExecuteChangedFor]`**, **`[property: …]`** forwarding. |
| [DelegateCommand](/generators/delegate-command) | Sync commands, **`CanExecute`**, **`Task`** execute, **`ValueTask`**. |
| [AsyncDelegateCommand](/generators/async-delegate-command) | Parallel runs, **`Catch`**, **`CancelAfter`**, **`ObservesCanExecute`**, Prism 8 vs 9 packages. |
| [ObservesProperty](/generators/observes-property) | Re-evaluate **`CanExecute`** when properties change. |
| [BindableBase](/generators/bindable-base) | Generated **INPC** for types not inheriting Prism **`BindableBase`**. |
| [BindableValidator](/generators/bindable-validator) | **`INotifyDataErrorInfo`** validation via **`[BindableValidator]`** and **`[NotifyDataErrorInfo]`**. |
| [Container registration](/generators/container-registration) | **`Register*`**, **`RegisterForNavigation`**, **`RegisterDialog`**, emitted **`IContainerRegistry`** calls. |
| [NavigationAware](/generators/navigation-aware) | **`INavigationAware`** lifecycle members; Prism 8 **`Prism.Regions`** and Prism 9 **`Prism.Navigation.Regions`**. |
| [DialogAware](/generators/dialog-aware) | **`IDialogAware`** members; Prism 8 **`Prism.Services.Dialogs`** and Prism 9 **`Prism.Dialogs`**. |
| [NavigateCommand](/generators/navigate-command) | **`IRegionManager.RequestNavigate`** via **`DelegateCommand`** or property-changed navigation. |
| [ShowDialogCommand](/generators/show-dialog-command) | **`IDialogService.ShowDialog`** via **`DelegateCommand`**. |

## Diagnostics

All compiler IDs are documented in **[Diagnostics reference](/diagnostics/reference)**.

## Next

- [Architecture overview](/architecture/overview)
- [Getting started](/getting-started)
