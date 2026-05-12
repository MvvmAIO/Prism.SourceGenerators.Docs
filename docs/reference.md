---
title: Reference and links
description: DeepWiki, GitHub, samples, repository layout, and build commands.
---

# External documentation

Use these alongside this site. Content on **DeepWiki** is community/AI indexed from the repository and may lag behind **main**.

!!! note "Languages"
    [简体中文](../zh-cn/reference/) · [日本語](../ja/reference/)

---

## Quick links

| Resource | Description |
|----------|-------------|
| **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** | Structured topics: incremental generator pipeline, shared helpers, packaging, multi-Roslyn targeting, CI, and testing. |
| **[GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators)** | Source, issues, pull requests, and CI badges for **MvvmAIO/Prism.SourceGenerators**. |
| **[Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | **Prism.SourceGenerators.Samples** — Avalonia projects consuming the package. |

---

## Repository structure

Core architecture uses a shared generator project plus multiple Roslyn-target projects for package compatibility.

```
Prism.SourceGenerators/
Prism.SourceGenerators.Roslyn4001/
Prism.SourceGenerators.Roslyn4031/
Prism.SourceGenerators.Roslyn4120/
Prism.SourceGenerators.Roslyn5000/
Prism.SourceGenerators.Core/
Prism.Bcl.Commands/
```

---

## Build and Nuke commands

Typical local workflow for build, test, pack, and publish from the **main source repository**:

```bash
dotnet build Prism.SourceGenerators.slnx
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
dotnet run --project build/_build.csproj -- --target Pack --configuration Release --version 0.2.0
dotnet run --project build/_build.csproj -- --target Publish --configuration Release --version 0.2.0 --nuget-api-key <NUGET_API_KEY>
```

---

## CI and quality signals

- **`.NET`** workflow badge tracks latest pipeline status on **`master`**.
- **`Tests`** badge reports pass/fail/skip counts from the latest run.
- Workflows upload **`test-results`** (`.trx`) artifacts for detailed diagnostics.

---

## Coverage scope on this site

This site summarizes README- and DeepWiki-oriented content: generator surfaces (`ObservableProperty`, command generators, notifications, observes, bindable-base), diagnostics (**PSG** series), compatibility expectations, project topology, build and release workflows, plus source links. For full canonical details and latest updates, always cross-check the **main README**.
