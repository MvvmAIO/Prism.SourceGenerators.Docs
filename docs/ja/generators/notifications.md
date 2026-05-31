---
title: 通知と属性の転送
description: NotifyPropertyChangedFor、NotifyCanExecuteChangedFor、property ターゲット転送。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# 通知と転送

## `[NotifyPropertyChangedFor]`

注釈付き **`[ObservableProperty]`** が変わったとき、追加のプロパティ名に対して **`PropertyChanged`** を発火します。

```csharp
[ObservableProperty]
[NotifyPropertyChangedFor(nameof(FullName))]
private string _firstName = "";
```

複数名前：**`nameof`** に複数引数、または属性を複数回。

## `[NotifyCanExecuteChangedFor]`

プロパティ更新後、名前付きコマンドで **`RaiseCanExecuteChanged()`** を呼びます。名前は既存のコマンドメンバー、または **`[DelegateCommand]`** / **`[AsyncDelegateCommand]`** が付いたメソッドから生成されたプロパティ（例：メソッド **`Save`** → **`SaveCommand`**）を指せます。

解決できない名前は **PSG2005**（警告）。setter は依然として生成されます。

## 生成プロパティへの属性転送

### フィールドターゲット

明示的 **`[property: Xxx]`** を使います。属性は**完全修飾**型名で生成プロパティにコピーされ、生成ファイルが **`using`** に依存しません。

```csharp
[ObservableProperty]
[property: System.Text.Json.Serialization.JsonIgnore]
private string _password = "";
```

### partial プロパティターゲット

**`partial`** 宣言の属性（ジェネレータ専用を除く）は実装宣言へ転送されます。

::: warning 属性引数
引数式は**そのまま**出力されます。**`nameof`**、**`typeof`**、リテラル、完全修飾型を推奨します。

:::

## 関連

- [ObservableProperty](/ja/generators/observable-property)
- [DelegateCommand](/ja/generators/delegate-command)
