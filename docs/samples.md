---
title: Samples
description: Avalonia sample applications that consume MvvmAIO.Prism.SourceGenerators.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# Samples

Runnable applications live in **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)**.

| Area | Notes |
|------|--------|
| **Prism 8** | Demonstrates **`MvvmAIO.Prism.Bcl.Commands`** when **`AsyncDelegateCommand`** is required. |
| **Prism 9** | Uses in-box async command types where applicable. |
| **Avalonia** | Full UI demos (Prism 8 / Prism 9). |
| **WPF** | Minimal `net8.0-windows` shell (Windows CI). |
| **.NET MAUI** | Headless ViewModel library — wire into `Prism.DryIoc.Maui`. |
| **Uno / WinUI** | Headless compatibility library with `[NavigationAware]`. |

Clone the repo and open the solution there to debug **ObservableProperty**, **commands**, and **registration** end-to-end.

## Repository layout

- **`Prism.SourceGenerators.Samples.slnx`** — open this solution in Visual Studio **17.13+** or Rider (`.slnx` support).
- **`Prism.SourceGenerators.Samples.Prism8`** — targets **`net8.0`**, Prism 8; uses **`MvvmAIO.Prism.Bcl.Commands`** when **`AsyncDelegateCommand`** is required.
- **`Prism.SourceGenerators.Samples.Prism9`** — targets **`net10.0`**, Prism 9 with in-box async commands; includes a **Validation** area (`BindableValidator`, `[NotifyDataErrorInfo]`, DataAnnotations).
- **`Prism.SourceGenerators.Samples.Wpf`** — **`net8.0-windows`** WPF + Prism 9.
- **`Prism.SourceGenerators.Samples.Maui`** — **`net9.0`** ViewModel library for MAUI integration.
- **`Prism.SourceGenerators.Samples.Uno`** — **`net9.0`** ViewModel library for Uno / WinUI compatibility checks.

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

- [Getting started](/getting-started)
- [Container registration](/generators/container-registration)
