---
title: BindableBase attribute
description: Generate INotifyPropertyChanged for types that do not inherit Prism BindableBase.
---

# `[BindableBase]`

For classes that **do not** inherit **`Prism.Mvvm.BindableBase`** (and do not already implement **INotifyPropertyChanged** through a base type), the generator can emit **`PropertyChanged`**, **`SetProperty<T>`**, **`RaisePropertyChanged`**, and **`OnPropertyChanged`** helpers so you can write Prism-style setters.

```csharp
[BindableBase]
public partial class SimpleViewModel
{
    private string _message = "Hello";

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
}
```

The containing type must be **`partial`** (**PSG0004**). If the type already inherits **`BindableBase`** or another **INPC** base, **no code is generated**.

## Related

- [ObservableProperty](observable-property.md)
- [Diagnostics reference](../diagnostics/reference.md)
