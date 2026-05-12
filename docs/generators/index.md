---
title: Generators
description: Index of source generator features for Prism MVVM.
---

# Generators

MvvmAIO.Prism.SourceGenerators extends **partial** types at compile time. Attributes live in **`MvvmAIO.Prism.Core`** (namespace **`Prism.SourceGenerators`**).

!!! tip "Partial types"
    **`partial`** is required wherever generated members merge into your declaration. **PSG0001–PSG0004** cover the common mistakes; all four have a **MakePartial** code fix in the IDE.

## Topics

| Topic | Summary |
|-------|---------|
| [ObservableProperty](observable-property.md) | Field and **C# 13+** partial-property targets, **`PropertyAccess`**, **`OnChanging` / `OnChanged`**. |
| [Notifications & forwarding](notifications.md) | **`[NotifyPropertyChangedFor]`**, **`[NotifyCanExecuteChangedFor]`**, **`[property: …]`** forwarding. |
| [DelegateCommand](delegate-command.md) | Sync commands, **`CanExecute`**, **`Task`** execute, **`ValueTask`**. |
| [AsyncDelegateCommand](async-delegate-command.md) | Parallel runs, **`Catch`**, **`CancelAfter`**, **`ObservesCanExecute`**, Prism 8 vs 9 packages. |
| [ObservesProperty](observes-property.md) | Re-evaluate **`CanExecute`** when properties change. |
| [BindableBase](bindable-base.md) | Generated **INPC** for types not inheriting Prism **`BindableBase`**. |
| [Container registration](container-registration.md) | **`Register*`**, **`RegisterForNavigation`**, **`RegisterDialog`**, emitted **`IContainerRegistry`** calls. |

## Diagnostics

All compiler IDs are documented in **[Diagnostics reference](../diagnostics/reference.md)**.

## Next

- [Architecture overview](../architecture/overview.md)
- [Getting started](../getting-started.md)
