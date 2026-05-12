---
title: BindableBase 特性
description: 为未继承 Prism BindableBase 的类型生成 INotifyPropertyChanged。
---

# `[BindableBase]`

对**不**继承 **`Prism.Mvvm.BindableBase`**（且未通过基类型实现 **INotifyPropertyChanged**）的类，生成器可发出 **`PropertyChanged`**、**`SetProperty<T>`**、**`RaisePropertyChanged`** 与 **`OnPropertyChanged`** 等辅助成员，便于编写 Prism 风格 setter。

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

包含类型须为 **`partial`**（**PSG0004**）。若类型已继承 **`BindableBase`** 或另一 **INPC** 基类，则**不生成代码**。

## 相关

- [ObservableProperty](observable-property.md)
- [诊断参考](../diagnostics/reference.md)
