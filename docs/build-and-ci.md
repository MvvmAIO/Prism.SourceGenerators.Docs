---
title: Build and CI
description: Solutions, Nuke targets, badges, and test artifacts.
---

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

## CI signals

- **`.NET` workflow badge** on the README tracks **`master`** pipeline health.
- **`Tests` badge** surfaces latest pass / fail / skip counts (see `.github/badges/tests.json` in the generator repo).
- Workflow uploads **`test-results`** (`.trx`) for IDE or `trx` viewers.

## Next

- [Contributing](contributing.md)
- [Diagnostics reference](diagnostics/reference.md)
