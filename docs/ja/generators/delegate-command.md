---
title: DelegateCommand
description: メソッドから同期および Task 非同期コマンドを生成。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# `[DelegateCommand]`

インスタンスメソッドから **`DelegateCommand`** / **`DelegateCommand<T>`** または **`AsyncDelegateCommand`** / **`AsyncDelegateCommand<T>`** を生成します。

## サポートされる Execute の形（要約）

- **`void`**、0 または 1 パラメータ → **`DelegateCommand`** / **`DelegateCommand<T>`**
- **`Task`**（非ジェネリック）、**`Task<TResult>`**、**`ValueTask`**、**`ValueTask<TResult>`** → **`AsyncDelegateCommand`**（`ValueTask` 系は **`.AsTask()`**；**`Task<TResult>`** は `async` lambda で execute を待機）
- **`CanExecute = nameof(...)`** → bool メソッドまたは互換デリゲート（不正時 **PSG2003**、**PSG2006**）

**`CancellationToken`** と **`ValueTask`** / **`ValueTask<TResult>`** / **`Task<TResult>`** の組み合わせは**非サポート**（**PSG1001**）。

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
- **C# 8–13** では、コマンドプロパティはバッキングフィールドと `_command ??= ...` を使います。
- **C# 7.3** でバージョン 0.8.1 を使うと、C# 8 が必要な `_command ??= ...` が生成されます。[#117](https://github.com/MvvmAIO/Prism.SourceGenerators/issues/117) の未リリースの修正では、`_command ?? (_command = ...)` でコマンドインスタンスをキャッシュします。

## 関連

- [AsyncDelegateCommand](/ja/generators/async-delegate-command)
- [ObservesProperty](/ja/generators/observes-property)
- [PSG1001、PSG3002](/ja/diagnostics/reference)
