---
title: AsyncDelegateCommand
description: 高度な非同期コマンド — 並列、Catch、キャンセル、Observes。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# `[AsyncDelegateCommand]`

**`Task`** ベースの非同期メソッドに、Prism 風オプションが必要なときに使います。

- **`EnableParallelExecution`**
- **`CancelAfter`**
- **`Catch`**（例外ハンドラ — 不正時 **PSG2001** / **PSG2002**）
- **`ObservesCanExecute`**（または **`[DelegateCommand]`** と **`[ObservesProperty]`** の併用）
- **`CancellationTokenSourceFactory`**（サポートされる場合）

```csharp
[AsyncDelegateCommand(EnableParallelExecution = true)]
private async Task FetchAsync() { }

[AsyncDelegateCommand(CanExecute = nameof(CanSave), Catch = nameof(HandleError))]
private async Task SaveAsync() { }
```

## Prism 8 と 9

- **Prism 9+**：**`AsyncDelegateCommand`** は Prism に同梱。
- **Prism.Core 8.1.97**：シンボル用に **`MvvmAIO.Prism.Bcl.Commands`** が必要。なければ **PSG3002**。

## 関連

- [DelegateCommand](/ja/generators/delegate-command)
- [PSG2001–PSG2006、PSG3002](/ja/diagnostics/reference)
