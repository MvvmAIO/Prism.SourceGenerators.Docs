---
layout: home
title: Overview
description: Compile-time MVVM for Prism — MvvmAIO.Prism.SourceGenerators documentation.

hero:
  name: Prism.SourceGenerators
  text: Compile-time MVVM for Prism
  tagline: MvvmAIO.Prism.SourceGenerators removes boilerplate for observable properties, commands, and container registration while preserving BindableBase semantics.
  actions:
    - theme: brand
      text: Getting started
      link: /getting-started
    - theme: alt
      text: Generators
      link: /generators/
    - theme: alt
      text: Diagnostics
      link: /diagnostics/reference

features:
  - title: Observable
    details: "[ObservableProperty] for fields and C# 13+ partial properties, with OnChanging / OnChanged hooks and [NotifyPropertyChangedFor]."
  - title: Commands
    details: "[DelegateCommand] and [AsyncDelegateCommand] from methods, including ValueTask support."
  - title: Registration
    details: Attributes such as [RegisterForNavigation] and [RegisterSingleton] emit IContainerRegistry registration code.
  - title: Diagnostics
    details: PSG diagnostics with code fixes (for example MakePartial) where the generator can guide you.
---

::: tip Canonical documentation
**This site** is the **authoritative manual** for the project—deeper and more structured than the GitHub **README**, **GitHub Wiki**, or exploratory mirrors such as DeepWiki. Start with **[About this site](/about-this-site)** for how those surfaces relate.
:::

::: info Languages / 语言 / 言語
This site is available in **[English](/)**, **[简体中文](/zh-cn/)**, and **[日本語](/ja/)**.
:::

## Where to read next

| Page | Purpose |
|------|---------|
| [Getting started](/getting-started) | Install packages, partial types, Prism 8 vs 9. |
| [Generators](/generators/) | Topic-by-topic generator reference. |
| [Diagnostics reference](/diagnostics/reference) | Every **PSG** ID in one table. |
| [Architecture](/architecture/overview) | Repos, layout, Roslyn multi-targeting. |
| [Build & CI](/build-and-ci) | slnx, Nuke, pipelines. |
| [Samples](/samples) | **Prism.SourceGenerators.Samples** (Avalonia, Prism 8/9). |

## Repository layout

- `Prism.SourceGenerators/` — shared generator logic (`.shproj` / `.projitems`).
- `Prism.SourceGenerators.Core/` — attributes consumed by your app and seen by the generator.
- `Prism.SourceGenerators.Roslyn*` — version-specific compiler targets for NuGet compatibility.
- `Prism.Bcl.Commands/` — optional Prism 8 `AsyncDelegateCommand` compatibility package.
- Sample Avalonia apps live in the separate **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** repository.

## NuGet packages

| Package | Role |
|---------|------|
| [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators) | Core source generator: `ObservableProperty`, command generation, container registration. |
| [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands) | Compatibility package for Prism 8 `AsyncDelegateCommand` scenarios. |

![NuGet downloads](https://img.shields.io/nuget/dt/MvvmAIO.Prism.SourceGenerators?logo=nuget)
![NuGet downloads BCL](https://img.shields.io/nuget/dt/MvvmAIO.Prism.Bcl.Commands?logo=nuget)

## Also useful (non-canonical)

- **[GitHub repository](https://github.com/MvvmAIO/Prism.SourceGenerators)** — issues, PRs, CI.
- **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** — exploratory outline; may lag or diverge from this site.
