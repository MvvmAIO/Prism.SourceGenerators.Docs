---
title: DialogAware
description: Generate Prism IDialogAware members with partial hooks.
---

# DialogAware

Apply **`[DialogAware]`** to a **partial** class inheriting **`BindableBase`** when **`Prism.Services.Dialogs.IDialogAware`** is available (Prism.Core).

## Usage

```csharp
using Prism.Mvvm;
using Prism.SourceGenerators;

[DialogAware(Title = "Confirm")]
public partial class ConfirmViewModel : BindableBase
{
    partial void OnDialogOpenedCore(IDialogParameters parameters) { }
}
```

## Generated members

- `Title` property (backed by `SetProperty`)
- `RequestClose` event
- `CanCloseDialog` → `CanCloseDialogCore` (default `true`)
- `OnDialogOpened` / `OnDialogClosed` → partial cores

## Diagnostics

| ID | When |
|----|------|
| **PSG0008** | Class is not `partial` |

## Related

- [Container registration](/generators/container-registration) — `[RegisterDialog]`
