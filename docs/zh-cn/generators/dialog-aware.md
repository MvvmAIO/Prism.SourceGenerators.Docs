---
title: DialogAware
description: 生成 Prism IDialogAware 成员与分部钩子。
---

# DialogAware

在继承 **`BindableBase`** 的 **partial** 类上使用 **`[DialogAware]`**，按引用程序集生成对话框契约：

- **Prism 9+**：`Prism.Dialogs`（`RequestClose` 为 **`DialogCloseListener`**）
- **Prism 8**：`Prism.Services.Dialogs`（`RequestClose` 为 **事件**）

用法与英文文档相同，见 [DialogAware（English）](/generators/dialog-aware)。

诊断：**PSG0008**（类须为 `partial`）。
