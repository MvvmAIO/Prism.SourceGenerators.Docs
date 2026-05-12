---
title: DelegateCommand
description: メソッドから同期および Task 非同期コマンドを生成。
---

# `[DelegateCommand]`

インスタンスメソッドから **`DelegateCommand`** / **`DelegateCommand<T>`** または **`AsyncDelegateCommand`** / **`AsyncDelegateCommand<T>`** を生成します。

## サポートされる Execute の形（要約）

- **`void`**、0 または 1 パラメータ → **`DelegateCommand`** / **`DelegateCommand<T>`**
- **`Task`**（非ジェネリック）、**`ValueTask`**、**`ValueTask<TResult>`** → **`AsyncDelegateCommand`**（必要に応じ **`.AsTask()`**）
- **`CanExecute = nameof(...)`** → bool メソッドまたは互換デリゲート（不正時 **PSG2003**、**PSG2006**）

**`Task<TResult>`** を execute の戻りにするのは**非サポート**（**PSG1001**）。**`CancellationToken`** と **`ValueTask`** の組み合わせには制限あり（**PSG1001** — 利用バージョンの製品テストを参照）。

## 例

```csharp
public partial class MainViewModel : BindableBase
{
    [DelegateCommand]
    private void Increment() { }

    [DelegateCommand]
    private async Task LoadAsync() { }

    [DelegateCommand(CanExecute = nameof(CanSubmit))]
    private void Submit() { }

    private bool CanSubmit() => true;
}
```

## C# 14+ とそれ以前

- **C# 14+**：コマンドプロパティに **`field`** キーワード（別フィールド不要）。
- **それ以前**：従来の **`_command`??=** 遅延フィールド。

## 関連

- [AsyncDelegateCommand](async-delegate-command.md)
- [ObservesProperty](observes-property.md)
- [PSG1001、PSG3002](../diagnostics/reference.md)
