---
title: ShowDialogCommand
description: 生成调用 IDialogService.ShowDialog 的 DelegateCommand。
---

# ShowDialogCommand

用 `[ShowDialogCommand]` 标记方法，会生成调用 `IDialogService.ShowDialog` 的 `DelegateCommand`。ViewModel 必须提供生成代码可访问的 `IDialogService` 实例。在下面的示例中，视图可以绑定 `ConfirmDeleteCommand` 来打开名为 `ConfirmDelete` 的对话框。

```csharp
using Prism.Dialogs; // Prism 9+
// using Prism.Services.Dialogs; // Prism 8
using Prism.Mvvm;
using Prism.SourceGenerators;

public partial class MainViewModel : BindableBase
{
    private readonly IDialogService _dialogService;

    public MainViewModel(IDialogService dialogService) => _dialogService = dialogService;

    [ShowDialogCommand(Name = "ConfirmDelete")]
    private void ConfirmDelete() { }

    partial void OnConfirmDeleteDialogClosed(IDialogResult result)
    {
        // 可选：在对话框关闭后处理结果。
    }
}
```

可用 `CommandName` 指定命令属性名，用 `DialogServiceMember` 指定提供对话框服务的成员。

## Prism 8 与 Prism 9 的对话框 API

| Prism | 对话框命名空间 | `RequestClose` 成员 |
|-------|----------------|---------------------|
| **9+** | `Prism.Dialogs`（Prism.Core） | `DialogCloseListener` 属性 |
| **8** | `Prism.Services.Dialogs`（平台程序集） | 事件 |

`[DialogAware]` 和 `[ShowDialogCommand]` 根据项目引用的程序集选择命名空间。

## 诊断

| ID | 触发条件 |
|----|----------|
| **PSG7101** | 找不到可访问的 `IDialogService` 成员。 |
| **PSG7102** | `[ShowDialogCommand]` 未指定对话框的 `Name`。 |

## 相关文档

- [DialogAware](/zh-cn/generators/dialog-aware)
- [容器注册](/zh-cn/generators/container-registration)：用 `[RegisterDialog]` 注册对话框。
