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

诊断：**PSG0008**（类须为 `partial`）。
