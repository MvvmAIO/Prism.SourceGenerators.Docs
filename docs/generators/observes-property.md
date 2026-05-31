---
title: ObservesProperty
description: Re-evaluate command CanExecute when properties change.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# `[ObservesProperty]`

Apply next to **`[DelegateCommand]`** or **`[AsyncDelegateCommand]`**. When any listed property changes, the generator wires logic so **`CanExecute`** is re-evaluated (mirrors Prism’s **`ObservesProperty`** behaviour).

```csharp
[ObservableProperty]
private bool _isValid;

[DelegateCommand(CanExecute = nameof(CanSubmit))]
[ObservesProperty(nameof(IsValid))]
private void Submit() { }
```

Multiple properties: **`[ObservesProperty(nameof(A), nameof(B))]`** or repeat the attribute. Unknown property names → **PSG2004**.

## Related

- [DelegateCommand](/generators/delegate-command)
- [AsyncDelegateCommand](/generators/async-delegate-command)
