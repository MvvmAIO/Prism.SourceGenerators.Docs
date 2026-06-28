---
title: Navigation & Dialog — advanced contracts (RFC)
description: Evaluation of typed parameters and advanced Prism navigation contracts after P2/P3.
---

# Navigation & Dialog — advanced contracts (RFC)

Status: **evaluated / deferred** after **0.7.0** (P2/P3 call-layer generators shipped).

## Context

**0.7.0** delivers:

- `[NavigationAware]` / `[DialogAware]` with Prism 8 (`Prism.Regions`, `Prism.Services.Dialogs`) and Prism 9+ (`Prism.Navigation.Regions`, `Prism.Dialogs`) namespace resolution
- `[NavigateCommand]` / `[NavigateOnChanged]` → `IRegionManager.RequestNavigate`
- `[ShowDialogCommand]` → `IDialogService.ShowDialog`

## Recommended next steps (not in 0.7.0)

| Idea | Value | Risk / cost | Recommendation |
|------|-------|-------------|----------------|
| **`[FromNavigationParameter]` / `[FromDialogParameter]`** | Safer typed reads from `NavigationContext` / `IDialogParameters` | Medium—needs default/missing semantics per type | **P4 candidate** after samples stabilize |
| **`IConfirmNavigationRequest`** | Less boilerplate for “unsaved changes” prompts | Low–medium; platform-specific UX still manual | **Defer** until `[NavigateCommand]` usage is validated in samples |
| **`IRegionMemberLifetime` (`KeepAlive`)** | Simple page cache | Low | **Small follow-up** if users request it |
| **`IJournalAware`** | Back-stack integration | Medium; journal APIs differ by platform | **Defer** |
| **Region name constant generation** | Fewer string typos | Low if scoped to const emission only | **Optional**; avoid XAML/view discovery |
| **`CloseDialog` helper on `[DialogAware]`** | Shorter VM code for Prism 9 `DialogCloseListener` | Low | **Consider** with `[DialogAware]` docs/examples |

## Explicitly out of scope

- IL weaving, runtime containers, or XAML rewriting
- Full navigation graph / state-machine generation
- `INavigationService` abstraction across MAUI vs desktop (differs too much from Region-first desktop samples)

## Acceptance for a future P4+ release

1. At least one sample flow uses typed parameter binding end-to-end.
2. New diagnostics use the **PSG7xxx** band consistently.
3. Prism 8 and 9 integration tests cover each new attribute against real **Prism.Core** (plus platform contracts where required).
