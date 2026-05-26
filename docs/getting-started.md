---
title: Getting started
description: Install MvvmAIO.Prism.SourceGenerators, use partial types, and validate your build.
---

# Install and reference

Add the NuGet package to a Prism app that uses **BindableBase** (or a compatible base). Use **partial** types where the generator requires them.

!!! note "Languages"
    [简体中文](../zh-cn/getting-started/) · [日本語](../ja/getting-started/)

---

## 1. Add the package

Install **MvvmAIO.Prism.SourceGenerators** from NuGet. It bundles the Core attributes assembly.

```bash
dotnet add package MvvmAIO.Prism.SourceGenerators
```

---

## 2. Use partial types

Annotate **partial** classes so the generator can extend them. Fix **PSG0001–PSG0004** with the **MakePartial** code fix when offered.

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    private string _title = "";
}
```

---

## 3. Prism 8 vs 9

On **Prism.Core 8.1.97** you may also need **MvvmAIO.Prism.Bcl.Commands** for `AsyncDelegateCommand`. **Prism 9** includes async commands in-box.

```bash
dotnet add package MvvmAIO.Prism.Bcl.Commands
```

---

## 4. Run the samples

Clone **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** for Avalonia demos targeting Prism 8 and Prism 9, then build **`Prism.SourceGenerators.Samples.slnx`**. Layout, validation demo, and **local vs NuGet** generator wiring are covered on **[Samples](samples.md)**.

---

## Requirements

- **.NET 10 SDK**
- **Visual Studio 2022 17.13+** / Rider / VS Code with C# Dev Kit (`.slnx` support)
- Prism app with **`BindableBase`** (or compatible base type)

---

## Recommended package setup

`MvvmAIO.Prism.SourceGenerators` bundles source generator attributes from `MvvmAIO.Prism.Core`. For Prism.Core **8.1.97** async commands, add `MvvmAIO.Prism.Bcl.Commands` manually.

```xml
<ItemGroup>
  <PackageReference Include="MvvmAIO.Prism.SourceGenerators" Version="0.5.0" />
  <!-- Prism 8.1.97 async command support -->
  <PackageReference Include="MvvmAIO.Prism.Bcl.Commands" Version="0.4.1" />
</ItemGroup>
```

Replace versions with the latest from NuGet.

---

## Build and validate

**Build product solution:**

```bash
dotnet build Prism.SourceGenerators.slnx
```

**Run CI-like local pipeline (Nuke) from the main generator repo:**

```bash
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

---

## Common upgrade notes

- **C# 13+** supports partial-property `[ObservableProperty]` targets using the `field` keyword.
- **C# 14+** command generation can use `field` directly (no private backing field).
- **`ValueTask` / `ValueTask<T>`** execute methods are supported by async command generation via `.AsTask()`.
- If async command symbols are missing, the generator reports **PSG3002** with package guidance.
