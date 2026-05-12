# Prism.SourceGenerators.Docs

Static documentation for **[MvvmAIO.Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)**, built with **[NuStreamDocs](https://github.com/glennawatson/NuStreamDocs)** on **.NET 10** (Material 3 theme, Markdown, Lunr search, syntax highlighting).

## Live site

**https://mvvmaio.github.io/Prism.SourceGenerators.Docs/**

Use **Settings → Pages** with **GitHub Actions** as the publishing source if the site is not live yet.

## Languages

- **English** — default tree under `docs/`
- **简体中文** — `docs/zh-cn/`
- **日本語** — `docs/ja/`

Navigation and copy live in Markdown; `mkdocs.yml` declares the sidebar structure consumed by `NuStreamDocs.Config.MkDocs`.

Responsive tweaks for desktop and mobile live in **`styles/responsive.css`**, wired through NuStreamDocs **`DocBuilder.AddExtraCss`** (the same role as mkdocs-material **`extra_css`**), registered immediately after **`UseMaterial3Theme()`** so rules load after the Material 3 bundle.

## Local build

```bash
dotnet run --project Prism.SourceGenerators.Docs.csproj
```

HTML is emitted to `./site` by default. Pass a different output folder:

```bash
dotnet run --project Prism.SourceGenerators.Docs.csproj ./dist
```

Optional environment variable **`DOCS_SITE_URL`** sets the canonical site URL (defaults to the GitHub Pages URL in `Program.cs`).

## Native AOT

The project enables **`<PublishAot>true</PublishAot>`** (plus **`<InvariantGlobalization>true</InvariantGlobalization>`** for invariant culture in the published binary). Markdown under **`docs/`** and **`mkdocs.yml`** are copied next to the executable so a published build can run without the repo layout.

Publish a native executable (pick a [RID](https://learn.microsoft.com/dotnet/core/rid-catalog) for your OS):

```bash
dotnet publish -c Release -r win-x64 --self-contained false
dotnet publish -c Release -r linux-x64 --self-contained false
dotnet publish -c Release -r osx-arm64 --self-contained false
```

Run the binary from the publish folder (for example `bin/Release/net10.0/win-x64/publish/` on Windows). Pass the output directory as the first argument, same as **`dotnet run`**:

```bash
./bin/Release/net10.0/linux-x64/publish/Prism.SourceGenerators.Docs /tmp/site-out
```

Day-to-day **`dotnet run`** still uses the managed/JIT build for a fast edit loop; CI runs **`dotnet publish`** once per workflow to ensure **linux-x64** AOT compiles.

Preview locally (example):

```bash
dotnet run --project Prism.SourceGenerators.Docs.csproj
dotnet tool install -g dotnet-serve
dotnet serve -d site -p 8080
```

## Related

| Link | Description |
|------|-------------|
| [Generator repo](https://github.com/MvvmAIO/Prism.SourceGenerators) | Packages and README |
| [Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples) | Avalonia demos |
| [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) | AI-indexed docs |

## License

MIT — see [LICENSE](LICENSE).
