---
title: Navigation & Dialog — advanced contracts (RFC)
description: Evaluation of typed parameters and advanced Prism navigation contracts after P2/P3.
---

# Navigation & Dialog — advanced contracts (RFC)

Status: **partially implemented** — P4 shipped in **0.8.0** / **0.8.1**; remaining items deferred (see below).

## Context

**0.7.0** delivers:

- `[NavigationAware]` / `[DialogAware]` with Prism 8 (`Prism.Regions`, `Prism.Services.Dialogs`) and Prism 9+ (`Prism.Navigation.Regions`, `Prism.Dialogs`) namespace resolution
- `[NavigateCommand]` / `[NavigateOnChanged]` → `IRegionManager.RequestNavigate`
- `[ShowDialogCommand]` → `IDialogService.ShowDialog`

**0.8.0** / **0.8.1** (P4) delivers:

- `[FromNavigationParameter]` / `[FromDialogParameter]` — typed parameter binding on `[ObservableProperty]` members
- **PSG7006–PSG7008** / **PSG7103–PSG7105** diagnostics
- **0.8.1** — fix **CS0579** when parameter attributes are used on partial properties (C# 13+)

Samples: **Prism 9** `DashboardViewModel` (`userId` navigation parameter) and `ConfirmDialogViewModel` (`message` dialog parameter) demonstrate end-to-end binding.

## Recommended next steps (not yet shipped)

| Idea | Value | Risk / cost | Recommendation |
|------|-------|-------------|----------------|
| **`IConfirmNavigationRequest`** | Less boilerplate for “unsaved changes” prompts | Low–medium; platform-specific UX still manual | **Defer** until `[NavigateCommand]` usage is validated in samples |
| **`IRegionMemberLifetime` (`KeepAlive`)** | Simple page cache | Low | **Small follow-up** if users request it |
| **`IJournalAware`** | Back-stack integration | Medium; journal APIs differ by platform | **Defer** |
| **Region name constant generation** | Fewer string typos | Low if scoped to const emission only | **Optional**; avoid XAML/view discovery |
| **`CloseDialog` helper on `[DialogAware]`** | Shorter VM code for Prism 9 `DialogCloseListener` | Low | **Consider** with `[DialogAware]` docs/examples |

## Explicitly out of scope

- IL weaving, runtime containers, or XAML rewriting
- Full navigation graph / state-machine generation
- `INavigationService` abstraction across MAUI vs desktop (differs too much from Region-first desktop samples)

## P4 acceptance (met in 0.8.x)

1. [x] At least one sample flow uses typed parameter binding end-to-end.
2. [x] New diagnostics use the **PSG7xxx** band consistently.
3. [x] Prism 8 and 9 integration tests cover each new attribute against real **Prism.Core** (plus platform contracts where required).
