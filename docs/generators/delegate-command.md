---
title: DelegateCommand
description: Sync and async Task commands from methods.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# `[DelegateCommand]`

Generates **`DelegateCommand`** / **`DelegateCommand<T>`** or **`AsyncDelegateCommand`** / **`AsyncDelegateCommand<T>`** from instance methods.

## Supported execute shapes (summary)

- **`void`** with zero or one parameter → **`DelegateCommand`** / **`DelegateCommand<T>`**
- **`Task`** (non-generic), **`Task<TResult>`**, **`ValueTask`**, **`ValueTask<TResult>`** → **`AsyncDelegateCommand`** (`ValueTask` family via **`.AsTask()`**; **`Task<TResult>`** via `async` lambda that awaits execute)
- **`CanExecute = nameof(...)`** → bool method or compatible delegate (**PSG2003**, **PSG2006** when invalid)

**`CancellationToken`** + **`ValueTask`** / **`ValueTask<TResult>`** / **`Task<TResult>`** is **not** supported (**PSG1001**).

## Example

```csharp
public partial class MainViewModel : BindableBase
{
    [DelegateCommand]
    private void Increment() { }

    [DelegateCommand]
    private async Task LoadAsync() { }

    [DelegateCommand(CanExecute = nameof(CanSubmit))]
    private void Submit() { }

    private bool CanSubmit() => true;
}
```

## C# 14+ vs earlier

- **C# 14+**: command properties can use the **`field`** keyword (no separate backing field).
- **Earlier**: traditional **`_command`??=** lazy field pattern.

## Related

- [AsyncDelegateCommand](/generators/async-delegate-command)
- [ObservesProperty](/generators/observes-property)
- [PSG1001, PSG3002](/diagnostics/reference)
