---
title: 源生成器
description: Prism MVVM 源生成器功能索引。
---

::: tip 语言 / Languages
本页另有 [English](/generators/) 和 [日本語](/ja/generators/) 版本。
:::

# 源生成器

**MvvmAIO.Prism.SourceGenerators** 在编译期扩展 **partial** 类型。特性定义在 **`MvvmAIO.Prism.Core`** 中（命名空间 **`Prism.SourceGenerators`**）。

::: tip partial 类型
凡生成成员要合并进你的声明处，类型须为 **`partial`**。**PSG0001–PSG0005** 覆盖常见错误；五项均提供 IDE **MakePartial** 代码修复。

:::

## 主题

| 主题 | 摘要 |
|------|------|
| [ObservableProperty](/zh-cn/generators/observable-property) | 字段与 **C# 13+** partial 属性目标、**`PropertyAccess`**、**`OnChanging` / `OnChanged`**。 |
| [通知与转发](/zh-cn/generators/notifications) | **`[NotifyPropertyChangedFor]`**、**`[NotifyCanExecuteChangedFor]`**、**`[property: …]`** 转发。 |
| [DelegateCommand](/zh-cn/generators/delegate-command) | 同步命令、**`CanExecute`**、**`Task`** 执行方法、**`ValueTask`**。 |
| [AsyncDelegateCommand](/zh-cn/generators/async-delegate-command) | 并行执行、**`Catch`**、**`CancelAfter`**、**`ObservesCanExecute`**、Prism 8 与 9 包差异。 |
| [ObservesProperty](/zh-cn/generators/observes-property) | 属性变化时重新求值 **`CanExecute`**。 |
| [BindableBase](/zh-cn/generators/bindable-base) | 未继承 Prism **`BindableBase`** 时生成 **INPC**。 |
| [BindableValidator](/zh-cn/generators/bindable-validator) | 通过 **`[BindableValidator]`** 和 **`[NotifyDataErrorInfo]`** 生成 **`INotifyDataErrorInfo`** 验证支持。 |
| [容器注册](/zh-cn/generators/container-registration) | **`Register*`**、**`RegisterForNavigation`**、**`RegisterDialog`**，生成 **`IContainerRegistry`** 调用。 |
| [NavigationAware](/zh-cn/generators/navigation-aware) | **`INavigationAware`** 生命周期；Prism 8 **`Prism.Regions`** / Prism 9 **`Prism.Navigation.Regions`**。 |
| [DialogAware](/zh-cn/generators/dialog-aware) | **`IDialogAware`**；Prism 8 **`Prism.Services.Dialogs`** / Prism 9 **`Prism.Dialogs`**。 |
| [NavigateCommand](/generators/navigate-command) | **`IRegionManager.RequestNavigate`** 命令生成（英文文档）。 |
| [ShowDialogCommand](/generators/show-dialog-command) | **`IDialogService.ShowDialog`** 命令生成（英文文档）。 |

## 诊断

全部编译器 ID 见 **[诊断参考](/zh-cn/diagnostics/reference)**。

## 下一步

- [架构总览](/zh-cn/architecture/overview)
- [快速开始](/zh-cn/getting-started)
