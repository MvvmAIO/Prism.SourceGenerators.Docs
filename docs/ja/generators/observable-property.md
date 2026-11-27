---
title: ObservableProperty
description: フィールドと partial プロパティターゲット、PropertyAccess、変更フック。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# `[ObservableProperty]`

**`Prism.Mvvm.BindableBase`**（または互換基底）を継承する型に observable プロパティを生成します。型（プロパティターゲットの場合はそのプロパティも）**`partial`** が必要です。

## フィールドターゲット

**private フィールド**に付与。生成プロパティは既定で **`public`**。**`PropertyAccess`** で可視性を変更できます。

バージョン 0.8.1 では、C# 7.3 で .NET Framework 4.8 を対象とするプロジェクトで、生成コードに CS8370 が発生することがあります。`LangVersion` を `8.0` に設定すると、ターゲットフレームワークを変更せずにこの問題を回避できます。[#117](https://github.com/MvvmAIO/Prism.SourceGenerators/issues/117) の修正により、同じフィールドとコマンドの例が C# 7.3 でコンパイルできるようになります。

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

- [通知と転送](/ja/generators/notifications)
- [診断：PSG0001、PSG0003](/ja/diagnostics/reference)
