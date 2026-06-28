---
title: NavigationAware
description: 生成 Prism INavigationAware 成员与分部钩子。
---

# NavigationAware

在 **partial** 类上使用 **`[NavigationAware]`**，可按引用程序集生成 **`INavigationAware`** 成员：

- **Prism 9+**：`Prism.Navigation.Regions`
- **Prism 8**：`Prism.Regions`（在 **Prism.Wpf** / **Prism.Avalonia** 等平台程序集中，**Prism.Core** 单独引用不包含该区域 API）

用法与英文文档相同，见 [NavigationAware（English）](/generators/navigation-aware)。

诊断：**PSG0007**（类须为 `partial`）。
