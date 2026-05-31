---
title: AsyncDelegateCommand
description: 高级异步命令 — 并行执行、Catch、取消、Observes。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# `[AsyncDelegateCommand]`

在需要 Prism 风格选项时对基于 **`Task`** 的异步方法使用：

- **`EnableParallelExecution`**
- **`CancelAfter`**
- **`Catch`**（异常处理程序 — 无效时 **PSG2001** / **PSG2002**）
- **`ObservesCanExecute`**（或与 **`[DelegateCommand]`** 上的 **`[ObservesProperty]`** 组合）
- **`CancellationTokenSourceFactory`**（在支持的版本中）

```csharp
[AsyncDelegateCommand(EnableParallelExecution = true)]
private async Task FetchAsync() { }

[AsyncDelegateCommand(CanExecute = nameof(CanSave), Catch = nameof(HandleError))]
private async Task SaveAsync() { }
```

## Prism 8 与 9

- **Prism 9+**：**`AsyncDelegateCommand`** 由 Prism 提供。
- **Prism.Core 8.1.97**：需安装 **`MvvmAIO.Prism.Bcl.Commands`** 以解析符号，否则 **PSG3002**。

## 相关

- [DelegateCommand](/zh-cn/generators/delegate-command)
- [PSG2001–PSG2006、PSG3002](/zh-cn/diagnostics/reference)
