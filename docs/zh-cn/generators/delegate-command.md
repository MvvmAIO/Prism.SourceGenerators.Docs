---
title: DelegateCommand
description: 由方法生成同步与 Task 异步命令。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# `[DelegateCommand]`

由实例方法生成 **`DelegateCommand`** / **`DelegateCommand<T>`** 或 **`AsyncDelegateCommand`** / **`AsyncDelegateCommand<T>`**。

## 支持的 Execute 形态（摘要）

- **`void`**，零或一个参数 → **`DelegateCommand`** / **`DelegateCommand<T>`**
- **`Task`**（非泛型）、**`Task<TResult>`**、**`ValueTask`**、**`ValueTask<TResult>`** → **`AsyncDelegateCommand`**（`ValueTask` 族经 **`.AsTask()`**；**`Task<TResult>`** 经 `async` lambda 等待 execute）
- **`CanExecute = nameof(...)`** → bool 方法或兼容委托（无效时 **PSG2003**、**PSG2006**）

**`CancellationToken`** 与 **`ValueTask`** / **`ValueTask<TResult>`** / **`Task<TResult>`** 的组合**不受支持**（**PSG1001**）。

## 示例

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

## C# 14+ 与更早版本

- **C# 14+**：命令属性可使用 **`field`** 关键字（无需单独后备字段）。
- **更早**：传统 **`_command`??=** 惰性字段模式。

## 相关

- [AsyncDelegateCommand](/zh-cn/generators/async-delegate-command)
- [ObservesProperty](/zh-cn/generators/observes-property)
- [PSG1001、PSG3002](/zh-cn/diagnostics/reference)
