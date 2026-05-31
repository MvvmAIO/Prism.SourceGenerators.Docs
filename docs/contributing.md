---
title: Contributing
description: How to contribute to generators vs documentation.
---
::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::


# Contributing

## Product (generators, Core, tests)

Follow **[CONTRIBUTING.md](https://github.com/MvvmAIO/Prism.SourceGenerators/blob/master/CONTRIBUTING.md)** in **Prism.SourceGenerators**: issues, branches, tests, and code style expectations.

## Documentation (this site)

- Repository: **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)**  
- Content: Markdown under **`docs/`**, navigation in **`.vitepress/config.mts`**, optional theme CSS in **`.vitepress/theme/custom.css`**.  
- Build locally: `dotnet run` (see README in that repo).

When you change **diagnostic IDs or user-visible messages**, update **[Diagnostics reference](/diagnostics/reference)** in the same PR as the product change, or immediately after, so this site stays authoritative.

## Next

- [About this site](/about-this-site)
- [Build & CI](/build-and-ci)
