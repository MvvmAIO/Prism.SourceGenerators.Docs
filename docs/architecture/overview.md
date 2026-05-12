---
title: Architecture overview
description: Repositories, shared generator project, and main generator entry points.
---

# Architecture overview

## Repositories

| Repository | Purpose |
|------------|---------|
| **[Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** | Source generators, **MvvmAIO.Prism.Core** attributes, packaging, tests, CI. |
| **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** | This static documentation site (NuStreamDocs). |
| **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | Avalonia sample apps (Prism 8 / 9). |

## Layout in Prism.SourceGenerators

```
Prism.SourceGenerators/           # Shared implementation (.shproj / .projitems)
Prism.SourceGenerators.Core/    # Attributes shipped as MvvmAIO.Prism.Core (referenced by apps + analyzers)
Prism.SourceGenerators.Roslyn*/ # Compiler-version-specific generator projects (NuGet compatibility)
Prism.Bcl.Commands/             # Optional Prism 8 AsyncDelegateCommand compatibility package
```

The **shared** project holds most generator logic. **Roslyn\*** projects reference the Roslyn API version that matches each published package; the build selects the appropriate target so consumers get a generator compiled against their toolchain.

## Major generators (conceptual)

| Area | Responsibility |
|------|------------------|
| **Observable / commands** | `[ObservableProperty]`, `[DelegateCommand]`, `[AsyncDelegateCommand]`, related attributes. |
| **Container** | Registration attributes → `PrismRegistrationExtensions.g.cs` → `IContainerRegistry` calls. |
| **BindableBase** | `[BindableBase]` INPC emission for types not inheriting Prism `BindableBase`. |

Each pipeline uses **Roslyn incremental generation** (`IIncrementalGenerator`) with **narrow attribute providers** where possible so recompilation stays cheap.

## Next

- [Roslyn targeting & packages](roslyn-targeting.md)
- [Build & CI](../build-and-ci.md)
