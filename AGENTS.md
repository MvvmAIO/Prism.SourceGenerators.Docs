# Prism.SourceGenerators.Docs

VitePress documentation site only for [MvvmAIO/Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators) (live at https://mvvmaio.github.io/Prism.SourceGenerators.Docs/). Source generators and analyzer changes belong in the main repository; Avalonia demos belong in [MvvmAIO/Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples).

## Build & Verify

```bash
npm install
npm run docs:dev
npm run docs:build
npm run docs:preview
```

- Deploys to GitHub Pages via `.github/workflows/github-pages.yml` on `main`.

## Docs & Language

- Keep guides paired in sync across English (`docs/`), Simplified Chinese (`docs/zh-cn/`), and Japanese (`docs/ja/`).
- Navigation and sidebars are configured in `.vitepress/config.mts`.
- Commit messages and GitHub Issue/PR text: **English**.
- Do not commit or push unless explicitly requested.
