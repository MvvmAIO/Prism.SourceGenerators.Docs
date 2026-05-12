---
title: Notifications and attribute forwarding
description: NotifyPropertyChangedFor, NotifyCanExecuteChangedFor, and property-target forwarding.
---

# Notifications and forwarding

## `[NotifyPropertyChangedFor]`

Raises **`PropertyChanged`** for additional property names when the annotated **`[ObservableProperty]`** changes.

```csharp
[ObservableProperty]
[NotifyPropertyChangedFor(nameof(FullName))]
private string _firstName = "";
```

Multiple names: use several arguments to **`nameof`** or apply the attribute multiple times.

## `[NotifyCanExecuteChangedFor]`

Calls **`RaiseCanExecuteChanged()`** on named commands after the property updates. Names may refer to an existing command member **or** the generated property for a method annotated with **`[DelegateCommand]`** / **`[AsyncDelegateCommand]`** (e.g. method **`Save`** → **`SaveCommand`**).

Unresolved names produce **PSG2005** (warning); the setter is still emitted.

## Forwarding attributes onto the generated property

### Field targets

Use explicit **`[property: Xxx]`** targets; those attributes are copied onto the generated property with **fully-qualified** type names so the generated file does not depend on your **`using`** list.

```csharp
[ObservableProperty]
[property: System.Text.Json.Serialization.JsonIgnore]
private string _password = "";
```

### Partial property targets

Attributes on the **`partial`** declaration (except generator-owned attributes) forward to the implementing declaration.

!!! warning "Attribute arguments"
    Argument expressions are emitted **verbatim**. Prefer **`nameof`**, **`typeof`**, literals, or fully-qualified types in attribute arguments.

## Related

- [ObservableProperty](observable-property.md)
- [DelegateCommand](delegate-command.md)
