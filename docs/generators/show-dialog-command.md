---
title: ShowDialogCommand
description: Generate DelegateCommand wrappers that call IDialogService.ShowDialog.
---

# ShowDialogCommand

Generate a **`DelegateCommand`** that calls **`IDialogService.ShowDialog`**. The ViewModel must already expose an accessible **`IDialogService`** instance.

```csharp
using Prism.Dialogs; // Prism 9+
// using Prism.Services.Dialogs; // Prism 8
using Prism.Mvvm;
using Prism.SourceGenerators;

public partial class MainViewModel : BindableBase
{
    private readonly IDialogService _dialogService;

    public MainViewModel(IDialogService dialogService) => _dialogService = dialogService;

    [ShowDialogCommand(Name = "ConfirmDelete")]
    private void ConfirmDelete() { }

    partial void OnConfirmDeleteDialogClosed(IDialogResult result)
    {
        // Optional callback after the dialog closes.
    }
}
```

Optional attribute properties: **`CommandName`**, **`DialogServiceMember`**.

## Prism 8 vs Prism 9 dialogs

| Prism | Dialog API namespace |
|-------|---------------------|
| **9+** | `Prism.Dialogs` (**Prism.Core**); `RequestClose` is a **`DialogCloseListener`** property |
| **8** | `Prism.Services.Dialogs` (platform assembly); `RequestClose` is an **`event`** |

`[DialogAware]` and `[ShowDialogCommand]` resolve the namespace from referenced assemblies.

## Diagnostics

| ID | When |
|----|------|
| **PSG7101** | No accessible `IDialogService` member |
| **PSG7102** | `[ShowDialogCommand]` missing `Name` |

## Related

- [DialogAware](/generators/dialog-aware)
- [Container registration](/generators/container-registration) — `[RegisterDialog]`
