---
title: ShowDialogCommand
description: IDialogService.ShowDialog を呼び出す DelegateCommand を生成します。
---

# ShowDialogCommand

メソッドに `[ShowDialogCommand]` を付けると、`IDialogService.ShowDialog` を呼び出す `DelegateCommand` が生成されます。ViewModel には、生成コードからアクセスできる `IDialogService` のインスタンスが必要です。次の例では、ビューを `ConfirmDeleteCommand` にバインドすると、`ConfirmDelete` という名前のダイアログを開けます。

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
        // 必要に応じて、ダイアログを閉じた後に結果を処理します。
    }
}
```

`CommandName` でコマンドプロパティ名を、`DialogServiceMember` でダイアログサービスを提供するメンバーを指定できます。

## Prism 8 と Prism 9 のダイアログ API

| Prism | ダイアログの名前空間 | `RequestClose` メンバー |
|-------|----------------------|-------------------------|
| **9+** | `Prism.Dialogs`（Prism.Core） | `DialogCloseListener` プロパティ |
| **8** | `Prism.Services.Dialogs`（プラットフォームのアセンブリ） | イベント |

`[DialogAware]` と `[ShowDialogCommand]` は、参照先のアセンブリに応じて名前空間を選びます。

## 診断

| ID | 発生条件 |
|----|----------|
| **PSG7101** | アクセスできる `IDialogService` メンバーが見つからない。 |
| **PSG7102** | `[ShowDialogCommand]` にダイアログの `Name` が指定されていない。 |

## 関連項目

- [DialogAware](/ja/generators/dialog-aware)
- [コンテナー登録](/ja/generators/container-registration)：`[RegisterDialog]` によるダイアログの登録。
