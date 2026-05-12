---
title: ObservesProperty
description: プロパティ変更時にコマンドの CanExecute を再評価。
---

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

- [DelegateCommand](delegate-command.md)
- [AsyncDelegateCommand](async-delegate-command.md)
