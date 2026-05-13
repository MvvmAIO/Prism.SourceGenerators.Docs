---
title: Samples
description: Avalonia sample applications that consume MvvmAIO.Prism.SourceGenerators.
---

# Samples

Runnable applications live in **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)**.

| Area | Notes |
|------|--------|
| **Prism 8** | Demonstrates **`MvvmAIO.Prism.Bcl.Commands`** when **`AsyncDelegateCommand`** is required. |
| **Prism 9** | Uses in-box async command types where applicable. |
| **Avalonia** | UI stack for the demos; generator usage is UI-framework agnostic. |

Clone the repo and open the solution there to debug **ObservableProperty**, **commands**, and **registration** end-to-end.

## Repository layout

- **`Prism.SourceGenerators.Samples.slnx`** — open this solution in Visual Studio **17.13+** or Rider (`.slnx` support).
- **`Prism.SourceGenerators.Samples.Prism8`** — targets **`net8.0`**, Prism 8; uses **`MvvmAIO.Prism.Bcl.Commands`** when **`AsyncDelegateCommand`** is required.
- **`Prism.SourceGenerators.Samples.Prism9`** — targets **`net10.0`**, Prism 9 with in-box async commands; includes a **Validation** area (`BindableValidator`, `[NotifyDataErrorInfo]`, DataAnnotations).

## Build

You need a **.NET 10 SDK** (for the Prism 9 project) and **.NET 8** SDK/runtime as required for **`net8.0`**.

```bash
git clone https://github.com/MvvmAIO/Prism.SourceGenerators.Samples.git
cd Prism.SourceGenerators.Samples
dotnet build Prism.SourceGenerators.Samples.slnx
```

## Local generators vs NuGet

If you clone **[Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** as a **sibling folder** (`../Prism.SourceGenerators`), **`Directory.Build.props`** switches samples to **project references** instead of the **`MvvmAIO.Prism.SourceGenerators`** NuGet package—useful when developing the generator. Overrides and details: **`build/README-LocalSourceGenerators.md`** in the samples repo (`UseLocalPrismSourceGenerators`).

## Next

- [Getting started](getting-started.md)
- [Container registration](generators/container-registration.md)
