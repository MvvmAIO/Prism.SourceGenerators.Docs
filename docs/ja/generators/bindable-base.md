---
title: BindableBase 属性
description: Prism BindableBase を継承しない型へ INotifyPropertyChanged を生成。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# `[BindableBase]`

**`Prism.Mvvm.BindableBase`** を継承しておらず（基底で **INotifyPropertyChanged** も実装していない）クラスに対し、**`PropertyChanged`**、**`SetProperty<T>`**、**`RaisePropertyChanged`**、**`OnPropertyChanged`** などを生成し、Prism 風 setter を書けるようにします。

```csharp
[BindableBase]
public partial class SimpleViewModel
{
    private string _message = "Hello";

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
}
```

包含型は **`partial`**（**PSG0004**）。既に **`BindableBase`** または別の **INPC** 基底を継承している場合は**コードを生成しません**。

## 関連

- [ObservableProperty](/ja/generators/observable-property)
- [診断リファレンス](/ja/diagnostics/reference)
