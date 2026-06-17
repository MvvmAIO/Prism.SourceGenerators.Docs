---
title: Ecosystem positioning
description: How MvvmAIO.Prism.SourceGenerators relates to CommunityToolkit.Mvvm and Prism commercial tooling.
---

# Ecosystem positioning

**MvvmAIO.Prism.SourceGenerators** is an **MIT-licensed**, **open-source** Roslyn source generator package for **Prism** MVVM apps. It is maintained by the MvvmAIO community and is **not** affiliated with the Prism Library commercial product.

## Who is this for?

| Audience | Why this package |
|----------|------------------|
| **Prism 8.1.97 (MIT) users** | Modern `[ObservableProperty]` / command generation without leaving `BindableBase` and `DelegateCommand`. |
| **Prism 9 Community License users** | Same developer experience with Prism 9 APIs; optional `MvvmAIO.Prism.Bcl.Commands` only for Prism 8. |
| **Teams comparing MVVM toolkits** | Prism-native semantics instead of swapping to `ObservableObject` / `RelayCommand`. |

## Comparison with CommunityToolkit.Mvvm

| Topic | CommunityToolkit.Mvvm | MvvmAIO.Prism.SourceGenerators |
|-------|----------------------|--------------------------------|
| Base type | `ObservableObject` | `Prism.Mvvm.BindableBase` (or generated `[BindableBase]`) |
| Commands | `RelayCommand` / `AsyncRelayCommand` | `DelegateCommand` / `AsyncDelegateCommand` |
| DI / navigation | Not Prism-specific | `[Register]`, `[RegisterForNavigation]`, `[NavigationAware]`, `[DialogAware]` |
| License | MIT | MIT |
| Partial properties | Supported (C# 14) | Supported (C# 13+); **PSG6001** suggests field → partial property migration |

Use **CommunityToolkit** when you are not on Prism. Use **this package** when you want toolkit-style ergonomics **without** abandoning Prism types.

## Prism commercial tooling (context only)

Prism 9+ ships under a **dual Community / Commercial** license. The Prism team has described **commercial companion tooling** (analyzers, source generators, and related productivity packages) for paid tiers.

**MvvmAIO.Prism.SourceGenerators** is an **independent open-source alternative** focused on:

- Source generators only (no IL weaving)
- Prism 8 **and** Prism 9 compatibility
- Published on **NuGet.org** under **MIT**

This is not a statement about feature parity with any commercial product; compare release notes and documentation when choosing a stack.

## Design principles

1. **Preserve Prism semantics** — generated setters call `SetProperty`; commands use Prism command types.
2. **Multi-Roslyn matrix** — one NuGet package selects the correct analyzer for your SDK.
3. **Documented diagnostics** — every **PSG** rule is listed in [Diagnostics](/diagnostics/reference).

## Next steps

- [Getting started](/getting-started)
- [Samples](/samples) (Avalonia, WPF, MAUI ViewModels, Uno/WinUI compatibility)
- [Generators overview](/generators/)
