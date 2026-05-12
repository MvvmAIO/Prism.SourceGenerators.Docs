---
title: Overview
description: Compile-time MVVM for Prism — MvvmAIO.Prism.SourceGenerators documentation.
---

# Compile-time MVVM for Prism

**MvvmAIO.Prism.SourceGenerators** removes boilerplate for observable properties, commands, and container registration while preserving **BindableBase** semantics.

!!! success "Canonical documentation"
    **This site** is the **authoritative manual** for the project—deeper and more structured than the GitHub **README**, **GitHub Wiki**, or exploratory mirrors such as DeepWiki. Start with **[About this site](about-this-site.md)** for how those surfaces relate.

!!! note "Languages / 语言 / 言語"
    This site is available in **[English](.)**, **[简体中文](zh-cn/)**, and **[日本語](ja/)**.

---

## What you get

| Area | What the generators do |
|------|-------------------------|
| **Observable** | `[ObservableProperty]` for fields and C# 13+ partial properties, with `OnChanging` / `OnChanged` hooks and `[NotifyPropertyChangedFor]`. |
| **Commands** | `[DelegateCommand]` and `[AsyncDelegateCommand]` from methods, including `ValueTask` support. |
| **Registration** | Attributes such as `[RegisterForNavigation]` and `[RegisterSingleton]` emit `IContainerRegistry` registration code. |
| **Diagnostics** | **PSG** diagnostics with code fixes (for example **MakePartial**) where the generator can guide you. |

---

## Where to read next

| Page | Purpose |
|------|---------|
| [Getting started](getting-started.md) | Install packages, partial types, Prism 8 vs 9. |
| [Generators](generators/index.md) | Topic-by-topic generator reference. |
| [Diagnostics reference](diagnostics/reference.md) | Every **PSG** ID in one table. |
| [Architecture](architecture/overview.md) | Repos, layout, Roslyn multi-targeting. |
| [Build & CI](build-and-ci.md) | `slnx`, Nuke, pipelines. |
| [Samples](samples.md) | **Prism.SourceGenerators.Samples** (Avalonia, Prism 8/9). |

---

## Repository layout

- `Prism.SourceGenerators/` — shared generator logic (`.shproj` / `.projitems`).
- `Prism.SourceGenerators.Core/` — attributes consumed by your app and seen by the generator.
- `Prism.SourceGenerators.Roslyn*` — version-specific compiler targets for NuGet compatibility.
- `Prism.Bcl.Commands/` — optional Prism 8 `AsyncDelegateCommand` compatibility package.
- Sample Avalonia apps live in the separate **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** repository.

---

## NuGet packages

| Package | Role |
|---------|------|
| [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators) | Core source generator: `ObservableProperty`, command generation, container registration. |
| [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands) | Compatibility package for Prism 8 `AsyncDelegateCommand` scenarios. |

![NuGet downloads](https://img.shields.io/nuget/dt/MvvmAIO.Prism.SourceGenerators?logo=nuget)
![NuGet downloads BCL](https://img.shields.io/nuget/dt/MvvmAIO.Prism.Bcl.Commands?logo=nuget)

---

## Also useful (non-canonical)

- **[GitHub repository](https://github.com/MvvmAIO/Prism.SourceGenerators)** — issues, PRs, CI.
- **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** — exploratory outline; may lag or diverge from this site.

---

_This documentation site is built with [.NET 10](https://dotnet.microsoft.com/) and **[NuStreamDocs](https://github.com/glennawatson/NuStreamDocs)** (Material 3 theme, Lunr search, static HTML)._
