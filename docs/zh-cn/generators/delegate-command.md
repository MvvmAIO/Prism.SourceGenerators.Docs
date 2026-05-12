---
title: DelegateCommand
description: 由方法生成同步与 Task 异步命令。
---

# `[DelegateCommand]`

由实例方法生成 **`DelegateCommand`** / **`DelegateCommand<T>`** 或 **`AsyncDelegateCommand`** / **`AsyncDelegateCommand<T>`**。

## 支持的 Execute 形态（摘要）

- **`void`**，零或一个参数 → **`DelegateCommand`** / **`DelegateCommand<T>`**
- **`Task`**（非泛型）、**`ValueTask`**、**`ValueTask<TResult>`** → **`AsyncDelegateCommand`**（必要时经 **`.AsTask()`**）
- **`CanExecute = nameof(...)`** → bool 方法或兼容委托（无效时 **PSG2003**、**PSG2006**）

**`Task<TResult>`** 作为 execute 返回值**不受支持**（**PSG1001**）。**`CancellationToken`** 与 **`ValueTask`** 的组合存在限制（**PSG1001** — 以你所用版本的产品测试为准）。

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

- [AsyncDelegateCommand](async-delegate-command.md)
- [ObservesProperty](observes-property.md)
- [PSG1001、PSG3002](../diagnostics/reference.md)
