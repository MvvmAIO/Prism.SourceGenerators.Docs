---
title: 诊断参考
description: MvvmAIO.Prism.SourceGenerators 的 PSG 诊断 ID、严重级别与修复说明。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# 诊断参考

编译器诊断定义在 **`master`** 分支的 **`Prism.SourceGenerators/Diagnostics/DiagnosticDescriptors.cs`**。下表 **标题** 与描述符 **Title** 一致；带占位符的完整说明以编译器 **message** 为准。

::: info 帮助链接
描述符可能指向产品 README 的诊断小节；**本站本页** 推荐作为人工检索索引。

:::

## PSG0001–PSG0004 — 需要 `partial`

| ID | 严重级别 | Title（英文原文） |
|----|----------|-------------------|
| **PSG0001** | Error | Class with `[ObservableProperty]` members must be partial |
| **PSG0002** | Error | Class with command generation attribute must be partial |
| **PSG0003** | Error | Property with `[ObservableProperty]` must be partial |
| **PSG0004** | Error | Class with `[BindableBase]` must be partial |
| **PSG0005** | Error | Class with `[BindableValidator]` must be partial |
| **PSG0006** | Error | `[BindableValidator]` is only supported on classes |

**代码修复：** **PSG0001–PSG0005** 均可在 IDE 中使用 **MakePartial**（**Ctrl+.** / **Alt+Enter**）；自 v0.4.1 起 Code Fix 扩展覆盖 **PSG0005**。

## PSG1001–PSG1002 — 命令方法签名

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG1001** | Error | Invalid `[DelegateCommand]` method signature |
| **PSG1002** | Error | Invalid `[AsyncDelegateCommand]` method signature |

详见 [DelegateCommand](/zh-cn/generators/delegate-command) 与 [AsyncDelegateCommand](/zh-cn/generators/async-delegate-command)。

## PSG2001–PSG2006 — 名称、处理程序、签名

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG2001** | Warning | Catch handler not found |
| **PSG2002** | Warning | Catch handler has incompatible signature |
| **PSG2003** | Warning | CanExecute member not found |
| **PSG2004** | Warning | Observed property not found |
| **PSG2005** | Warning | `[NotifyCanExecuteChangedFor]` command not found |
| **PSG2006** | Warning | CanExecute member has incompatible signature |

## PSG3002 — AsyncDelegateCommand 包

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG3002** | Error | AsyncDelegateCommand package required for Prism prior to 9.0 |

安装 **`MvvmAIO.Prism.SourceGenerators`**；若在 **Prism.Core 8.1.97** 上，另加 **`MvvmAIO.Prism.Bcl.Commands`**，或升级到 **Prism 9+**。

## PSG4001–PSG4002 — 容器注册

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG4001** | Warning | ServiceType is not assignable from implementation type |
| **PSG4002** | Warning | ViewModelType could not be resolved |

详见 [容器注册](/zh-cn/generators/container-registration)。

## PSG5001 — 验证

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG5001** | Warning | `[NotifyDataErrorInfo]` requires `BindableValidator` base type |

`[NotifyDataErrorInfo]` 仅在类型继承自 `BindableValidator` 或使用了 `[BindableValidator]` 属性时才有效。否则生成的 setter 不会调用 `ValidateProperty`。详见 [BindableValidator](/zh-cn/generators/bindable-validator)。

## PSG0007–PSG0008 — 导航与对话框契约

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG0007** | Error | Class with `[NavigationAware]` must be partial |
| **PSG0008** | Error | Class with `[DialogAware]` must be partial |

## PSG7001–PSG7005 — 区域导航命令

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG7001** | Error | IRegionManager member not found |
| **PSG7002** | Error | Region is required for `[NavigateCommand]` |
| **PSG7003** | Error | Target is required for `[NavigateCommand]` |
| **PSG7004** | Error | `[NavigateOnChanged]` requires `[ObservableProperty]` |
| **PSG7005** | Error | TargetMember is required for `[NavigateOnChanged]` |

## PSG7101–PSG7102 — 对话框服务命令

| ID | 严重级别 | Title |
|----|----------|-------|
| **PSG7101** | Error | IDialogService member not found |
| **PSG7102** | Error | Name is required for `[ShowDialogCommand]` |

## 下一步

- [源生成器总览](/zh-cn/generators/)
- [贡献指南](/zh-cn/contributing)
