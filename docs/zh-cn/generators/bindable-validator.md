---
title: BindableValidator
description: 通过 [BindableValidator] 和 [NotifyDataErrorInfo] 生成 INotifyDataErrorInfo 验证支持。
---

# `[BindableValidator]` 与验证

`BindableValidator` 是一个抽象基类，同时实现 **`INotifyPropertyChanged`** 和 **`INotifyDataErrorInfo`**，由 `System.ComponentModel.DataAnnotations` 提供支持。生成器提供两种接入方式。

---

## 方式 A — 直接继承 `BindableValidator`

继承 `BindableValidator`，在属性上标注 `[ObservableProperty]` + `[NotifyDataErrorInfo]`。生成器会在每个 setter 中自动调用 `ValidateProperty(value, nameof(Property))`。

```csharp
public partial class LoginViewModel : BindableValidator
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "用户名不能为空。")]
    [MinLength(2, ErrorMessage = "至少 2 个字符。")]
    public partial string Username { get; set; } = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "邮箱不能为空。")]
    [EmailAddress(ErrorMessage = "请输入有效的邮箱地址。")]
    public partial string Email { get; set; } = "";
}
```

---

## 方式 B — 使用 `[BindableValidator]` 特性

对已有基类（或希望生成器自动接管一切）的类，标注 `[BindableValidator]`：

- 若类型**无已声明的基类**（仅 `object`），生成的 partial 将继承 `BindableValidator`。
- 若类型**已有基类**，生成器将 `INotifyDataErrorInfo` 和验证辅助成员直接注入 partial，复用层次结构中已有的 `INotifyPropertyChanged`。

类型须为 **`partial`**（**PSG0005**）。非 class 类型（struct、interface 等）会产生 **PSG0006**。

```csharp
[BindableValidator]
public partial class ProfileViewModel
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    private string _displayName = "";
}
```

---

## 类级别 `[NotifyDataErrorInfo]`

将 `[NotifyDataErrorInfo]` 标注在**类**上，可一次性对该类所有生成属性启用验证：

```csharp
[NotifyDataErrorInfo]
public partial class RegisterViewModel : BindableValidator
{
    [ObservableProperty]
    [Required]
    public partial string Username { get; set; } = "";

    [ObservableProperty]
    [EmailAddress]
    public partial string Email { get; set; } = "";
}
```

---

## 可用方法

`BindableValidator` 提供：

| 方法 | 说明 |
|------|------|
| `ValidateProperty(value, name)` | 验证单个属性，触发 `ErrorsChanged`。 |
| `ValidateAllProperties()` | 一次性验证所有属性。 |
| `ClearErrors(name)` | 清除指定属性的错误。 |
| `ClearAllErrors()` | 清除所有验证错误。 |
| `GetErrors(name)` | 返回当前错误（`IEnumerable`）。 |
| `HasErrors` | 存在任何属性错误时为 `true`。 |

---

## DataAnnotations 转发

在 **partial 属性**声明上的 `[Required]`、`[EmailAddress]`、`[MinLength]` 等 `ValidationAttribute` 派生特性**仅保留在用户声明上**——生成器不会将其重复附加到实现 partial，避免 **CS0579**，同时保持 `Validator` 元数据正确。

对于**字段**目标，未指定目标的 DataAnnotations 特性会被转发到生成属性，使验证器能够读取它们。

---

## 诊断

| ID | 严重级别 | 触发条件 |
|----|----------|----------|
| **PSG5001** | Warning | 使用了 `[NotifyDataErrorInfo]` 但类型未继承 `BindableValidator` 也未使用 `[BindableValidator]`——验证调用不会被生成。 |

---

## 相关

- [ObservableProperty](observable-property.md)
- [通知与转发](notifications.md)
- [诊断参考](../diagnostics/reference.md)
