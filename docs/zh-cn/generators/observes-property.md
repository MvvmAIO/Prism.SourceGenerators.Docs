---
title: ObservesProperty
description: 属性变化时重新求值命令 CanExecute。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# `[ObservesProperty]`

与 **`[DelegateCommand]`** 或 **`[AsyncDelegateCommand]`** 相邻使用。当所列任一属性变化时，生成器接线逻辑以重新求值 **`CanExecute`**（对齐 Prism **`ObservesProperty`** 行为）。

```csharp
[ObservableProperty]
private bool _isValid;

[DelegateCommand(CanExecute = nameof(CanSubmit))]
[ObservesProperty(nameof(IsValid))]
private void Submit() { }
```

多个属性：**`[ObservesProperty(nameof(A), nameof(B))]`** 或重复该特性。未知属性名 → **PSG2004**。

## 相关

- [DelegateCommand](/zh-cn/generators/delegate-command)
- [AsyncDelegateCommand](/zh-cn/generators/async-delegate-command)
