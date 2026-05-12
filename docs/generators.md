---
title: Generators
description: ObservableProperty, commands, registration attributes, and PSG diagnostics.
---

# Generator surface area

The following areas map closely to the **DeepWiki** table of contents and the **README** generator sections. Topics align with the [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) outline (incremental generator pipeline, command generators, registration internals, PSG diagnostics, packaging).

!!! note "Languages"
    [简体中文](../zh-cn/generators/) · [日本語](../ja/generators/)

---

## ObservableProperty

Field-backed and partial-property modes, **PropertyAccess**, forwarding attributes with `property:` target, and coordination with **`[NotifyPropertyChangedFor]`** / **`[NotifyCanExecuteChangedFor]`**.

---

## Commands

**`[DelegateCommand]`** and **`[AsyncDelegateCommand]`** from methods; can-execute patterns and command dependency refresh.

---

## Container registration

Registration attributes analyzed to emit **`Register` / `RegisterForNavigation`** calls for Prism **`IContainerRegistry`**.

---

## Diagnostics and fixes

**PSG** codes for unresolved symbols, invalid signatures, and partial-class requirements — many include IDE code fixes.

---

## `[ObservableProperty]` — two target modes

Field target works in all C# versions. Partial-property target works in **C# 13+** and generates implementation using **`field`**. Both modes support **`OnChanging` / `OnChanged`** partial hooks and can coexist.

```csharp
// Field target
[ObservableProperty]
private string _title = "Hello";

// Partial property target (C# 13+)
[ObservableProperty]
public partial string Title { get; set; } = "Hello";
```

---

## Dependent notifications

- **`[NotifyPropertyChangedFor]`** raises extra `PropertyChanged` events for dependent properties.
- **`[NotifyCanExecuteChangedFor]`** calls `RaiseCanExecuteChanged()` on named commands.
- Supports multiple names in one attribute or by repeating attributes.

```csharp
[ObservableProperty]
[NotifyPropertyChangedFor(nameof(FullName))]
[NotifyCanExecuteChangedFor(nameof(SaveCommand))]
private string _firstName = "";
```

---

## Command generators

- **`[DelegateCommand]`** supports `void`, `Task`, `ValueTask`, `ValueTask<TResult>` execute methods.
- **`[AsyncDelegateCommand]`** adds advanced options: parallel execution, catch handler, cancel-after, observes-can-execute.
- **C# 14+** can emit command properties with the **`field`** keyword (without an explicit private backing field).

```csharp
[DelegateCommand(CanExecute = nameof(CanSubmit))]
private void Submit() { }

[AsyncDelegateCommand(EnableParallelExecution = true, Catch = nameof(HandleError))]
private async Task FetchDataAsync() { }
```

---

## `[ObservesProperty]` and `[BindableBase]`

**`[ObservesProperty]`** auto re-evaluates command **`CanExecute`** when specified properties change. **`[BindableBase]`** can generate a full **`INotifyPropertyChanged`** implementation for classes that do not inherit Prism **`BindableBase`**.

```csharp
[BindableBase]
public partial class SimpleVm
{
    private string _message = "Hello";
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
}
```

---

## Diagnostics matrix (PSG)

| ID | Meaning |
|----|---------|
| **PSG0001–PSG0004** | Missing required **`partial`** declarations. |
| **PSG1001 / PSG1002** | Invalid execute method signatures for command attributes. |
| **PSG2001–PSG2006** | Catch / CanExecute / Observed / NotifyCanExecute symbol resolution or signature problems. |
| **PSG3002** | **`AsyncDelegateCommand`** symbol missing; install required packages or upgrade Prism. |

!!! info "Quick fixes"
    **PSG0001–PSG0004** include IDE quick-fixes to insert **`partial`** automatically.
