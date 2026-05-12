---
title: 源生成器
description: Prism MVVM 源生成器功能索引。
---

# 源生成器

**MvvmAIO.Prism.SourceGenerators** 在编译期扩展 **partial** 类型。特性定义在 **`MvvmAIO.Prism.Core`** 中（命名空间 **`Prism.SourceGenerators`**）。

!!! tip "partial 类型"
    凡生成成员要合并进你的声明处，类型须为 **`partial`**。**PSG0001–PSG0004** 覆盖常见错误；四项均提供 IDE **MakePartial** 代码修复。

## 主题

| 主题 | 摘要 |
|------|------|
| [ObservableProperty](observable-property.md) | 字段与 **C# 13+** partial 属性目标、**`PropertyAccess`**、**`OnChanging` / `OnChanged`**。 |
| [通知与转发](notifications.md) | **`[NotifyPropertyChangedFor]`**、**`[NotifyCanExecuteChangedFor]`**、**`[property: …]`** 转发。 |
| [DelegateCommand](delegate-command.md) | 同步命令、**`CanExecute`**、**`Task`** 执行方法、**`ValueTask`**。 |
| [AsyncDelegateCommand](async-delegate-command.md) | 并行执行、**`Catch`**、**`CancelAfter`**、**`ObservesCanExecute`**、Prism 8 与 9 包差异。 |
| [ObservesProperty](observes-property.md) | 属性变化时重新求值 **`CanExecute`**。 |
| [BindableBase](bindable-base.md) | 未继承 Prism **`BindableBase`** 时生成 **INPC**。 |
| [容器注册](container-registration.md) | **`Register*`**、**`RegisterForNavigation`**、**`RegisterDialog`**，生成 **`IContainerRegistry`** 调用。 |

## 诊断

全部编译器 ID 见 **[诊断参考](../diagnostics/reference.md)**。

## 下一步

- [架构总览](../architecture/overview.md)
- [快速开始](../getting-started.md)
