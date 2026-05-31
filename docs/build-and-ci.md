---
title: Build and CI
description: Solutions, Nuke targets, badges, and test artifacts.
---

::: tip Languages
This page is also available in [简体中文](/zh-cn/) and [日本語](/ja/).
:::

# Build and CI

## Solutions

| File | Contents |
|------|----------|
| **`Prism.SourceGenerators.slnx`** | Main product projects (generators, Core, Bcl). |
| **`Prism.SourceGenerators.Full.slnx`** | Product + Nuke; documentation site lives in **Prism.SourceGenerators.Docs** (separate repo today). |
| **`build.slnx`** | Build orchestration project only. |

## Local commands (Nuke)

```bash
# CI-like pipeline: clean, restore, compile, test
dotnet run --project build/_build.csproj -- --target Ci --configuration Release

# Pack NuGet packages
dotnet run --project build/_build.csproj -- --target Pack --configuration Release --version 0.2.0

# Publish to NuGet.org
dotnet run --project build/_build.csproj -- --target Publish --configuration Release --version 0.2.0 --nuget-api-key <NUGET_API_KEY>
```

## Documentation site (this repo)

| Task | Command |
|------|---------|
| Dev server | `npm install` then `npm run docs:dev` |
| Production build | `npm run docs:build` |
| Preview build | `npm run docs:preview` |

Local dev URL: `http://localhost:5173/Prism.SourceGenerators.Docs/`

**GitHub Actions** (`.github/workflows/github-pages.yml`) runs `npm ci` and `npm run docs:build` on pull requests; deploys to GitHub Pages on push to **`main`**.

## CI signals

- **`.NET` workflow badge** on the README tracks **`master`** pipeline health.
- **`Tests` badge** surfaces latest pass / fail / skip counts (see `.github/badges/tests.json` in the generator repo).
- Workflow uploads **`test-results`** (`.trx`) for IDE or `trx` viewers.

## Next

- [Contributing](/contributing)
- [Diagnostics reference](/diagnostics/reference)
