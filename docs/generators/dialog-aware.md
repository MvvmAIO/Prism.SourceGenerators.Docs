---
title: DialogAware
description: Generate Prism IDialogAware members with partial hooks.
---

# DialogAware

Apply **`[DialogAware]`** to a **partial** class inheriting **`BindableBase`** when a dialog contract is available:

| Prism | Namespace | `RequestClose` shape |
|-------|-----------|----------------------|
| **9+** | `Prism.Dialogs` | `DialogCloseListener` property — call `RequestClose.Invoke(ButtonResult.OK)` |
| **8** | `Prism.Services.Dialogs` | `event Action<IDialogResult>` — call `RequestClose?.Invoke(new DialogResult(...))` |

On Prism 9, **`Title`** is omitted when `IDialogAware` has no title member (set title on the view/window instead).

## Usage (Prism 9)

```csharp
using Prism.Dialogs;
using Prism.Mvvm;
using Prism.SourceGenerators;

[DialogAware(Title = "Confirm")]
public partial class ConfirmViewModel : BindableBase
{
    [DelegateCommand]
    private void Ok() => RequestClose.Invoke(ButtonResult.OK);

    partial void OnDialogOpenedCore(IDialogParameters parameters) { }
}
```

## Generated members

- `Title` when the contract exposes it (Prism 8)
- `RequestClose` (event or `DialogCloseListener`, depending on Prism version)
- `CanCloseDialog` → `CanCloseDialogCore` (default `true`)
- `OnDialogOpened` / `OnDialogClosed` → partial cores

## `[FromDialogParameter]`

Apply **`[FromDialogParameter]`** to an `[ObservableProperty]` field or partial property to read a typed value from `IDialogParameters` via `TryGetValue<T>` and assign it through the property setter before `OnDialogOpenedCore` is invoked.

```csharp
[DialogAware(Title = "Confirm")]
public partial class ConfirmViewModel : BindableBase
{
    [FromDialogParameter("message")]
    [ObservableProperty]
    public partial string Message { get; set; } = "Default";
}
```

If the parameter is absent, the property retains its initial value. The key defaults to the property name when not specified.

## Diagnostics

| ID | When |
|----|------|
| **PSG0008** | Class is not `partial` |
| **PSG7103** | Attribute applied to a non-field/property member |
| **PSG7104** | Member lacks `[ObservableProperty]` |
| **PSG7105** | Key is empty |

## Related

- [ShowDialogCommand](/generators/show-dialog-command)
- [Container registration](/generators/container-registration) — `[RegisterDialog]`
