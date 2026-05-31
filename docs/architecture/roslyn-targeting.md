---
title: Roslyn targeting and packages
description: Why multiple Roslyn* projects exist and how they map to NuGet.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# Roslyn targeting and packages

## Why several `Prism.SourceGenerators.Roslyn*` projects?

Roslyn’s **public API surface** and **language feature sets** evolve per major compiler release. The product ships **multiple generator assemblies**, each built against a specific Roslyn version, so NuGet can deliver a package that matches the **minimum compiler** expected for that release line.

Typical mapping (names illustrative — check the repo for the exact set on `master`):

| Project folder | Intent |
|----------------|--------|
| `Roslyn4001` | Older VS / SDK stacks still on Roslyn 4.0.x. |
| `Roslyn4031` | Mid 4.x line. |
| `Roslyn4120` | Newer 4.12-era APIs. |
| `Roslyn5000` | Roslyn 5 / current C# feature frontier. |

**You do not reference these projects from an app.** The **MvvmAIO.Prism.SourceGenerators** package contains the correct precompiled generator for the supported SDK range declared by that package version.

## What you reference in an application

- **`MvvmAIO.Prism.SourceGenerators`** — analyzer + generator + **MvvmAIO.Prism.Core** (attributes).
- **`MvvmAIO.Prism.Bcl.Commands`** — optional when you need **`AsyncDelegateCommand`** on **Prism.Core 8.1.97**; see [PSG3002](/diagnostics/reference#psg3002) and [AsyncDelegateCommand](/generators/async-delegate-command).

## Next

- [Architecture overview](/architecture/overview)
- [Getting started](/getting-started)
