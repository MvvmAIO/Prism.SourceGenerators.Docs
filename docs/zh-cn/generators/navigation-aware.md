---
title: NavigationAware
description: 生成 Prism INavigationAware 成员与分部钩子。
---

# NavigationAware

在 **partial** 类上使用 **`[NavigationAware]`**，可按引用程序集生成 **`INavigationAware`** 成员：

- **Prism 9+**：`Prism.Navigation.Regions`
- **Prism 8**：`Prism.Regions`（在 **Prism.Wpf** / **Prism.Avalonia** 等平台程序集中，**Prism.Core** 单独引用不包含该区域 API）

用法与英文文档相同，见 [NavigationAware（English）](/generators/navigation-aware)。

## `[FromNavigationParameter]`

在 `[ObservableProperty]` 字段或 partial property 上应用 **`[FromNavigationParameter]`**，可在 `OnNavigatedToCore` 调用之前，通过 `TryGetValue<T>` 从 `NavigationContext.Parameters` 读取类型化值并通过属性 setter 赋值。

```csharp
[NavigationAware]
public partial class DashboardViewModel : BindableBase
{
    [FromNavigationParameter("userId")]
    [ObservableProperty]
    public partial int UserId { get; set; }

    [FromNavigationParameter]  // key 默认为 "UserName"
    [ObservableProperty]
    public partial string UserName { get; set; }
}
```

如果参数不存在，属性保留其初始值。未指定时 key 默认为属性名。

诊断：**PSG0007**（类须为 `partial`）、**PSG7006**（属性应用于非字段/属性成员）、**PSG7007**（成员缺少 `[ObservableProperty]`）、**PSG7008**（key 为空）。
