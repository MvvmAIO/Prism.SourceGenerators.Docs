---
title: Reference and links
description: External resources, repository layout, and build commands.
---

# Reference and links

Use these resources together with the **[main navigation](index.md)**. For semantics, diagnostics, and architecture, **prefer the pages on this site** over third-party mirrors.

!!! note "Languages"
    [简体中文](zh-cn/reference.md) · [日本語](ja/reference.md)

---

## Quick links

| Resource | Description |
|----------|-------------|
| **[GitHub — Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** | Source, issues, pull requests, CI. |
| **[GitHub Wiki](https://github.com/MvvmAIO/Prism.SourceGenerators/wiki)** ([`wiki/` tree](https://github.com/MvvmAIO/Prism.SourceGenerators/tree/master/wiki)) | Short topic notes; **not** canonical—use this site for depth. |
| **[GitHub — Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** | This documentation site (Markdown, `mkdocs.yml`, publishing workflow). |
| **[GitHub — Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | Runnable Avalonia samples (Prism 8 and 9). |
| **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** | AI-indexed mirror of the generator repo—handy for exploration, **not** a contract for behaviour or diagnostic text. |

---

## On this site

| Topic | Page |
|-------|------|
| Generator topics | [Generators](generators/index.md) |
| **PSG** diagnostics | [Diagnostics reference](diagnostics/reference.md) |
| CI and local build | [Build & CI](build-and-ci.md) |
| Product vs docs contributions | [Contributing](contributing.md) |

---

## Repository structure (generator repo)

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

Typical local workflow from the **generator** repository root:

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

## README, Wiki, and this site

The product **README** files (English / 简体中文 / 日本語) and the **[GitHub Wiki](https://github.com/MvvmAIO/Prism.SourceGenerators/wiki)** are **brief entry points**. **[About this site](about-this-site.md)** explains how they relate to **this site**, which remains the **canonical manual**.
