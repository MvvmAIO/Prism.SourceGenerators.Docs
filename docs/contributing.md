---
title: Contributing
description: How to contribute to generators vs documentation.
---

# Contributing

## Product (generators, Core, tests)

Follow **[CONTRIBUTING.md](https://github.com/MvvmAIO/Prism.SourceGenerators/blob/master/CONTRIBUTING.md)** in **Prism.SourceGenerators**: issues, branches, tests, and code style expectations.

## Documentation (this site)

- Repository: **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)**  
- Content: Markdown under **`docs/`**, navigation in **`mkdocs.yml`**, optional **`styles/responsive.css`**.  
- Build locally: `dotnet run` (see README in that repo).

When you change **diagnostic IDs or user-visible messages**, update **[Diagnostics reference](diagnostics/reference.md)** in the same PR as the product change, or immediately after, so this site stays authoritative.

## Next

- [About this site](about-this-site.md)
- [Build & CI](build-and-ci.md)
