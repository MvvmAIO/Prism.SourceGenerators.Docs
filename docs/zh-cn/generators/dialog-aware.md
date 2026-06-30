---
title: DialogAware
description: 生成 Prism IDialogAware 成员与分部钩子。
---

# DialogAware

在继承 **`BindableBase`** 的 **partial** 类上使用 **`[DialogAware]`**，按引用程序集生成对话框契约：

- **Prism 9+**：`Prism.Dialogs`（`RequestClose` 为 **`DialogCloseListener`**）
- **Prism 8**：`Prism.Services.Dialogs`（`RequestClose` 为 **事件**）

> **Prism 9 的 `Title` 省略说明：** Prism 9 将 `Title` 移至 view/window 层，`IDialogAware` 不再包含 title 成员。生成器检测到目标契约无 title 成员时会自动省略 `Title`，请在视图或窗口上设置标题。

用法与英文文档相同，见 [DialogAware（English）](/generators/dialog-aware)。

## `[FromDialogParameter]`

在 `[ObservableProperty]` 字段或 partial property 上应用 **`[FromDialogParameter]`**，可在 `OnDialogOpenedCore` 调用之前，通过 `TryGetValue<T>` 从 `IDialogParameters` 读取类型化值并通过属性 setter 赋值。

```csharp
[DialogAware(Title = "Confirm")]
public partial class ConfirmViewModel : BindableBase
{
    [FromDialogParameter("message")]
    [ObservableProperty]
    public partial string Message { get; set; } = "Default";
}
```

如果参数不存在，属性保留其初始值。未指定时 key 默认为属性名。

诊断：**PSG0008**（类须为 `partial`）、**PSG7103**（属性应用于非字段/属性成员）、**PSG7104**（成员缺少 `[ObservableProperty]`）、**PSG7105**（key 为空）。
