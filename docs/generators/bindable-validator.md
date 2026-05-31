---
title: BindableValidator
description: Generate INotifyDataErrorInfo validation support via [BindableValidator] and [NotifyDataErrorInfo].
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# `[BindableValidator]` and validation

`BindableValidator` is an abstract base class that implements both **`INotifyPropertyChanged`** and **`INotifyDataErrorInfo`**, backed by `System.ComponentModel.DataAnnotations`. The generator can wire it up automatically in two ways.

---

## Option A — inherit `BindableValidator` directly

Inherit `BindableValidator` and mark properties with `[ObservableProperty]` + `[NotifyDataErrorInfo]`. The generator emits `ValidateProperty(value, nameof(Property))` in each setter.

```csharp
public partial class LoginViewModel : BindableValidator
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(2, ErrorMessage = "At least 2 characters.")]
    public partial string Username { get; set; } = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public partial string Email { get; set; } = "";
}
```

---

## Option B — use `[BindableValidator]` attribute

For classes that already have a base class (or simply want the generator to wire everything up), annotate the partial class with `[BindableValidator]`:

- If the type has **no declared base** (only `object`), the generated partial inherits `BindableValidator`.
- If the type **already has a base**, the generator emits `INotifyDataErrorInfo` and validation helpers directly into the partial, reusing any existing `INotifyPropertyChanged` from the hierarchy.

The type must be **`partial`** (**PSG0005**). Non-class types (structs, interfaces) produce **PSG0006**.

```csharp
[BindableValidator]
public partial class ProfileViewModel
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Display name is required.")]
    [MaxLength(20, ErrorMessage = "20 characters max.")]
    public partial string DisplayName { get; set; } = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
    public partial int Age { get; set; }
}
```

When the class has **no explicit base type**, the generator makes the partial inherit `BindableValidator`:

```csharp
// Generated (simplified)
public partial class ProfileViewModel : Prism.SourceGenerators.BindableValidator { }
```

All `ValidateProperty` calls, `HasErrors`, and other members come from `BindableValidator` automatically.

---

## Class-level `[NotifyDataErrorInfo]`

Apply `[NotifyDataErrorInfo]` to the **class** to enable validation on **all** generated properties in one go:

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

## Available methods

`BindableValidator` exposes:

| Method | Description |
|--------|-------------|
| `ValidateProperty(value, name)` | Validate a single property; updates `ErrorsChanged`. |
| `ValidateAllProperties()` | Run validation on every property at once. |
| `ClearErrors(name)` | Clear errors for a specific property. |
| `ClearAllErrors()` | Clear all validation errors. |
| `GetErrors(name)` | Return current errors (`IEnumerable`). |
| `HasErrors` | `true` when any property has errors. |

---

## DataAnnotations forwarding

`[Required]`, `[EmailAddress]`, `[MinLength]` and other `ValidationAttribute`-derived attributes placed on a **partial property** declaration stay on the user's declaration only — the generator does **not** re-emit them on the implementing partial, avoiding **CS0579** while keeping `Validator` metadata correct.

For **field** targets, untargeted DataAnnotations attributes are forwarded to the generated property so the validator can see them.

---

## Diagnostic

| ID | Severity | Condition |
|----|----------|-----------|
| **PSG5001** | Warning | `[NotifyDataErrorInfo]` used but the type does not inherit `BindableValidator` or use `[BindableValidator]` — validation calls will not be emitted. |

---

## Related

- [ObservableProperty](/generators/observable-property)
- [Notifications & forwarding](/generators/notifications)
- [Diagnostics reference](/diagnostics/reference)
