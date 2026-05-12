---
title: About this documentation
description: How this site relates to the GitHub README, Wiki, DeepWiki, and the product source.
---

# About this documentation

This site is the **canonical, versioned product manual** for **MvvmAIO.Prism.SourceGenerators**. It is maintained in **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** and published to **GitHub Pages**.

## How this compares to other surfaces

| Surface | Role |
|--------|------|
| **This site** | Curated structure, generator semantics, diagnostics, architecture, build, and contribution paths. Intended to stay **accurate and navigable** as the first stop for authors. |
| **[GitHub README](https://github.com/MvvmAIO/Prism.SourceGenerators/blob/master/README.md)** (and localized READMEs) | Short landing-page overview and copy-paste snippets. **Not** the full manual. |
| **[GitHub Wiki](https://github.com/MvvmAIO/Prism.SourceGenerators/wiki)** ([`wiki/` in the product repo](https://github.com/MvvmAIO/Prism.SourceGenerators/tree/master/wiki)) | Short, topic-oriented notes (Chinese-first). Useful for onboarding threads; **not** a contract for diagnostic text or API guarantees. |
| **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** | AI-indexed mirror of the repo; useful for exploration, **not** a contract for API or diagnostic text. |
| **Samples repo** | Runnable Avalonia apps; see [Samples](samples.md). |

When in doubt, **diagnostic titles and messages** in the **Prism.SourceGenerators** repository (`DiagnosticDescriptors.cs`) remain the **runtime contract** for compiler output; this site documents them in plain language in [Diagnostics reference](diagnostics/reference.md).

## Languages

**English** pages under `docs/` are the default authoring language. **简体中文** (`zh-cn/`) and **日本語** (`ja/`) mirror the same information architecture—architecture, generators, diagnostics, build, samples, and reference—with full translated bodies for those sections. If a future page lands in English first, localized nav entries may point at the English file until a translation PR lands.

## Contributing to docs

Documentation changes go through **Prism.SourceGenerators.Docs** (Markdown + `mkdocs.yml` + optional `styles/`). Product code and generator behaviour live in **Prism.SourceGenerators**; see [Contributing](contributing.md).
