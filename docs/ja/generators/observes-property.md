---
title: ObservesProperty
description: プロパティ変更時にコマンドの CanExecute を再評価。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# `[ObservesProperty]`

**`[DelegateCommand]`** または **`[AsyncDelegateCommand]`** の隣に付けます。列挙したプロパティのいずれかが変わると、**`CanExecute`** を再評価するよう配線します（Prism **`ObservesProperty`** に相当）。

```csharp
[ObservableProperty]
private bool _isValid;

[DelegateCommand(CanExecute = nameof(CanSubmit))]
[ObservesProperty(nameof(IsValid))]
private void Submit() { }
```

複数プロパティ：**`[ObservesProperty(nameof(A), nameof(B))]`** または属性を繰り返す。未知の名前 → **PSG2004**。

## 関連

- [DelegateCommand](/ja/generators/delegate-command)
- [AsyncDelegateCommand](/ja/generators/async-delegate-command)
