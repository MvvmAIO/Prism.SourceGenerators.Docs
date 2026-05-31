# Prism.SourceGenerators.Docs

Static documentation for **[MvvmAIO.Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)**, built with **[VitePress](https://vitepress.dev/)** (Markdown, local search, syntax highlighting).

## Live site

**https://mvvmaio.github.io/Prism.SourceGenerators.Docs/**

Use **Settings → Pages** with **GitHub Actions** as the publishing source if the site is not live yet.

## Languages

- **English** — default tree under `docs/`
- **简体中文** — `docs/zh-cn/` (URLs under `/zh-cn/`)
- **日本語** — `docs/ja/` (URLs under `/ja/`)

Navigation and sidebars are declared in **`.vitepress/config.mts`**. Responsive layout tweaks live in **`.vitepress/theme/custom.css`**.

## Local development

```bash
npm install
npm run docs:dev
```

Open **http://localhost:5173/Prism.SourceGenerators.Docs/**

Production build and preview:

```bash
npm run docs:build
npm run docs:preview
```

Output is written to **`.vitepress/dist`**.

## Related

| Link | Description |
|------|-------------|
| [Generator repo](https://github.com/MvvmAIO/Prism.SourceGenerators) | Packages and README |
| [Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples) | Avalonia demos |
| [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) | AI-indexed docs |

## License

MIT — see [LICENSE](LICENSE).
