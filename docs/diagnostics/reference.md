---
title: Diagnostics reference
description: PSG diagnostic IDs, severities, and fixes for MvvmAIO.Prism.SourceGenerators.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# Diagnostics reference

Compiler diagnostics are defined in **`Prism.SourceGenerators/Diagnostics/DiagnosticDescriptors.cs`** on **`master`**. Titles below match the **descriptor title**; see the compiler **message** for parameterised text.

::: info Help link
Descriptors point at the product README diagnostics section; **this page** is the preferred human index.

:::
## PSG0001–PSG0004 — `partial` requirements

| ID | Severity | Title |
|----|----------|-------|
| **PSG0001** | Error | Class with `[ObservableProperty]` members must be partial |
| **PSG0002** | Error | Class with command generation attribute must be partial |
| **PSG0003** | Error | Property with `[ObservableProperty]` must be partial |
| **PSG0004** | Error | Class with `[BindableBase]` must be partial |
| **PSG0005** | Error | Class with `[BindableValidator]` must be partial |
| **PSG0006** | Error | `[BindableValidator]` is only supported on classes |

**Code fix:** **MakePartial** is available for **PSG0001–PSG0005** in the IDE (**Ctrl+.** / **Alt+Enter**).

## PSG1001–PSG1002 — command signatures

| ID | Severity | Title |
|----|----------|-------|
| **PSG1001** | Error | Invalid `[DelegateCommand]` method signature |
| **PSG1002** | Error | Invalid `[AsyncDelegateCommand]` method signature |

See [DelegateCommand](/generators/delegate-command) and [AsyncDelegateCommand](/generators/async-delegate-command).

## PSG2001–PSG2006 — names, handlers, signatures

| ID | Severity | Title |
|----|----------|-------|
| **PSG2001** | Warning | Catch handler not found |
| **PSG2002** | Warning | Catch handler has incompatible signature |
| **PSG2003** | Warning | CanExecute member not found |
| **PSG2004** | Warning | Observed property not found |
| **PSG2005** | Warning | `[NotifyCanExecuteChangedFor]` command not found |
| **PSG2006** | Warning | CanExecute member has incompatible signature |

## PSG3002 — AsyncDelegateCommand package

| ID | Severity | Title |
|----|----------|-------|
| **PSG3002** | Error | AsyncDelegateCommand package required for Prism prior to 9.0 |

Install **`MvvmAIO.Prism.SourceGenerators`** and, on **Prism.Core 8.1.97**, **`MvvmAIO.Prism.Bcl.Commands`**, or upgrade to **Prism 9+**.

## PSG4001–PSG4002 — container registration

| ID | Severity | Title |
|----|----------|-------|
| **PSG4001** | Warning | ServiceType is not assignable from implementation type |
| **PSG4002** | Warning | ViewModelType could not be resolved |

See [Container registration](/generators/container-registration).

## PSG5001 — validation

| ID | Severity | Title |
|----|----------|-------|
| **PSG5001** | Warning | `[NotifyDataErrorInfo]` requires `BindableValidator` base type |

`[NotifyDataErrorInfo]` is only effective when the containing type inherits from `BindableValidator` or is annotated with `[BindableValidator]`. Without it the generated setter will not call `ValidateProperty`. See [BindableValidator](/generators/bindable-validator).

## Next

- [Generators overview](/generators/)
- [Contributing](/contributing)
