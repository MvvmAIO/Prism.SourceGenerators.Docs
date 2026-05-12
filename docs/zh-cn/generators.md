---
title: 源生成器
---

# 生成器范围

下列主题与 DeepWiki 目录及 README 中的生成器章节大致对应。

!!! note "语言"
    [English](../generators/) · [日本語](../ja/generators/)

## ObservableProperty

字段与 partial property、`PropertyAccess`、`property:` 转发，以及与 **`[NotifyPropertyChangedFor]`** / **`[NotifyCanExecuteChangedFor]`** 的配合。

## 命令

从方法生成 **`[DelegateCommand]`** 与 **`[AsyncDelegateCommand]`**；CanExecute 与依赖刷新。

## 容器注册

分析注册特性，为 Prism **`IContainerRegistry`** 生成 **`Register` / `RegisterForNavigation`** 等调用。

## 诊断与修复

**PSG** 代码；许多附带 IDE 代码修复。

## 双目标模式示例

```csharp
[ObservableProperty]
private string _title = "Hello";

[ObservableProperty]
public partial string Title { get; set; } = "Hello";
```

## 依赖通知

```csharp
[ObservableProperty]
[NotifyPropertyChangedFor(nameof(FullName))]
[NotifyCanExecuteChangedFor(nameof(SaveCommand))]
private string _firstName = "";
```

## 命令生成器示例

```csharp
[DelegateCommand(CanExecute = nameof(CanSubmit))]
private void Submit() { }

[AsyncDelegateCommand(EnableParallelExecution = true, Catch = nameof(HandleError))]
private async Task FetchDataAsync() { }
```

## 诊断矩阵（PSG）

| ID | 含义 |
|----|------|
| PSG0001–PSG0004 | 缺少必须的 **`partial`**。 |
| PSG1001 / PSG1002 | 命令 execute 方法签名无效。 |
| PSG2001–PSG2006 | Catch/CanExecute/Observed/NotifyCanExecute 相关问题。 |
| PSG3002 | 缺少 **`AsyncDelegateCommand`** 符号。 |

!!! info "快速修复"
    **PSG0001–PSG0004** 支持自动插入 **`partial`** 的快速修复。
