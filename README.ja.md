# Prism.SourceGenerators.Docs

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語**

**[MvvmAIO.Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** 向けの静的ドキュメントサイトです（**[VitePress](https://vitepress.dev/)** 製・Markdown / ローカル検索 / シンタックスハイライト対応）。

## 公開サイト

**https://mvvmaio.github.io/Prism.SourceGenerators.Docs/**

まだ公開されていない場合は、**Settings → Pages** の公開ソースに **GitHub Actions** を選択してください。

## 対応言語

- **English** — `docs/` 配下のデフォルトツリー
- **简体中文** — `docs/zh-cn/`（URL パス `/zh-cn/`）
- **日本語** — `docs/ja/`（URL パス `/ja/`）

ナビゲーションとサイドバーは **`.vitepress/config.mts`**、レスポンシブレイアウト調整は **`.vitepress/theme/custom.css`** に定義されています。

## ローカル開発

```bash
npm install
npm run docs:dev
```

**http://localhost:5173/Prism.SourceGenerators.Docs/** を開きます。

本番ビルドとプレビュー：

```bash
npm run docs:build
npm run docs:preview
```

出力先は **`.vitepress/dist`** です。

## 関連リンク

| リンク | 説明 |
|------|-------------|
| [Generator repo](https://github.com/MvvmAIO/Prism.SourceGenerators) | パッケージと README |
| [Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples) | Avalonia・WPF・MAUI・Uno サンプル |
| [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) | インデックス済みドキュメント |

## ライセンス

MIT — [LICENSE](LICENSE) を参照してください。
