---
title: 通知与特性转发
description: NotifyPropertyChangedFor、NotifyCanExecuteChangedFor 与 property 目标转发。
---

# 通知与转发

## `[NotifyPropertyChangedFor]`

当所标注的 **`[ObservableProperty]`** 变更时，为额外属性名引发 **`PropertyChanged`**。

```csharp
[ObservableProperty]
[NotifyPropertyChangedFor(nameof(FullName))]
private string _firstName = "";
```

多个名称：对 **`nameof`** 传多个参数，或重复标注该特性。

## `[NotifyCanExecuteChangedFor]`

在属性更新后，对命名的命令调用 **`RaiseCanExecuteChanged()`**。名称可指向已有命令成员 **或** 由 **`[DelegateCommand]`** / **`[AsyncDelegateCommand]`** 标注方法生成的命令属性（例如方法 **`Save`** → **`SaveCommand`**）。

无法解析的名称会产生 **PSG2005**（警告）；setter 仍会生成。

## 将特性转发到生成属性上

### 字段目标

使用显式 **`[property: Xxx]`** 目标；这些特性会以**完全限定**类型名复制到生成属性上，使生成文件不依赖你的 **`using`** 列表。

```csharp
[ObservableProperty]
[property: System.Text.Json.Serialization.JsonIgnore]
private string _password = "";
```

### Partial 属性目标

声明在 **`partial`** 上的特性（生成器自有特性除外）会转发到实现声明。

!!! warning "特性实参"
    实参表达式会**原样**发出。实参请优先使用 **`nameof`**、**`typeof`**、字面量或完全限定类型。

## 相关

- [ObservableProperty](observable-property.md)
- [DelegateCommand](delegate-command.md)
