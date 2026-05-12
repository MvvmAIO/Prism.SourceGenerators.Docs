---
title: ObservableProperty
description: フィールドと partial プロパティターゲット、PropertyAccess、変更フック。
---

# `[ObservableProperty]`

**`Prism.Mvvm.BindableBase`**（または互換基底）を継承する型に observable プロパティを生成します。型（プロパティターゲットの場合はそのプロパティも）**`partial`** が必要です。

## フィールドターゲット（全 C# 版）

**private フィールド**に付与。生成プロパティは既定で **`public`**。**`PropertyAccess`** で可視性を変更できます。

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    private string _title = "Hello";

    [ObservableProperty(PropertyAccess.Internal)]
    private int _count;
}
```

setter は **`EqualityComparer<T>.Default`** で早期リターンし、続けて **`SetProperty`** を呼びます（**`BindableBase`** の意味論・オーバーライドを維持）。**`[NotifyPropertyChangedFor]`** と **`[NotifyCanExecuteChangedFor]`** はその後に実行されます。

## partial プロパティターゲット（C# 13+、`field`）

**`partial`** プロパティに付与。ジェネレータが **`field`** バック実装を出力します。

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    public partial string Title { get; set; } = "Hello";
}
```

可視性はプロパティ宣言に従います。このモードでは **`PropertyAccess`** は無視されます。

## `OnChanging` / `OnChanged` フック

実装可能な **`partial`** メソッド（例：**`OnAgeChanging`**、**`OnAgeChanged`**）を宣言し、ストレージ更新の**前後**で呼び出します（正確なオーバーロードの組は製品 README を参照）。

## 関連

- [通知と転送](notifications.md)
- [診断：PSG0001、PSG0003](../diagnostics/reference.md)
