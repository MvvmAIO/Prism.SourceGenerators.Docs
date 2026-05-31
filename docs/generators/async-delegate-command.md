---
title: AsyncDelegateCommand
description: Advanced async commands — parallel execution, catch, cancel, observes.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# `[AsyncDelegateCommand]`

Use for **`Task`**-based async methods when you need Prism-style options:

- **`EnableParallelExecution`**
- **`CancelAfter`**
- **`Catch`** (exception handler — **PSG2001** / **PSG2002** if invalid)
- **`ObservesCanExecute`** (or pair with **`[ObservesProperty]`** on **`[DelegateCommand]`**)
- **`CancellationTokenSourceFactory`** (where supported)

```csharp
[AsyncDelegateCommand(EnableParallelExecution = true)]
private async Task FetchAsync() { }

[AsyncDelegateCommand(CanExecute = nameof(CanSave), Catch = nameof(HandleError))]
private async Task SaveAsync() { }
```

## Prism 8 vs 9

- **Prism 9+**: **`AsyncDelegateCommand`** ships with Prism.
- **Prism.Core 8.1.97**: install **`MvvmAIO.Prism.Bcl.Commands`** so the symbol exists; otherwise **PSG3002**.

## Related

- [DelegateCommand](/generators/delegate-command)
- [PSG2001–PSG2006, PSG3002](/diagnostics/reference)
