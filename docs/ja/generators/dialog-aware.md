---
title: DialogAware
description: Prism IDialogAware メンバーを生成。
---

# DialogAware

**partial** クラスに **`[DialogAware]`** を付与すると **`IDialogAware`** メンバーが生成されます。

> **Prism 9 での `Title` 省略について:** Prism 9 では `Title` が view/window 層に移動し、`IDialogAware` に title メンバが含まれません。ジェネレータは対象契約に title メンバがない場合 `Title` を自動的に省略します。タイトルはビューまたはウィンドウで設定してください。

詳細は [英語版](/generators/dialog-aware) を参照。

## `[FromDialogParameter]`

**`[FromDialogParameter]`** を `[ObservableProperty]` フィールドまたは partial property に付与すると、`OnDialogOpenedCore` が呼び出される前に `TryGetValue<T>` で `IDialogParameters` から型付き値を読み取り、プロパティ setter を通じて代入します。

```csharp
[DialogAware(Title = "Confirm")]
public partial class ConfirmViewModel : BindableBase
{
    [FromDialogParameter("message")]
    [ObservableProperty]
    public partial string Message { get; set; } = "Default";
}
```

パラメータが存在しない場合、プロパティは初期値を保持します。key を省略した場合はプロパティ名が既定値になります。

診断: **PSG0008**（クラスが `partial` でない）、**PSG7103**（属性がフィールド/プロパティ以外のメンバに適用された）、**PSG7104**（メンバに `[ObservableProperty]` がない）、**PSG7105**（key が空）。
