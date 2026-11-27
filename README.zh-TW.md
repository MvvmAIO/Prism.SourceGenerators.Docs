# Prism.SourceGenerators.Docs

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md)

**[MvvmAIO.Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** 的靜態文件網站，使用 **[VitePress](https://vitepress.dev/)** 建置（支援 Markdown、本機搜尋與語法突顯）。

## 線上網站

**https://mvvmaio.github.io/Prism.SourceGenerators.Docs/**

若網站尚未啟用，請於儲存庫 **Settings → Pages** 將發布來源設定為 **GitHub Actions**。

## 多語言

- **English** — `docs/` 下的預設文件樹
- **简体中文** — `docs/zh-cn/`（URL 路徑 `/zh-cn/`）
- **日本語** — `docs/ja/`（URL 路徑 `/ja/`）

導覽與側邊欄定義於 **`.vitepress/config.mts`**，響應式版面調整位於 **`.vitepress/theme/custom.css`**。

## 本機開發

```bash
npm install
npm run docs:dev
```

開啟 **http://localhost:5173/Prism.SourceGenerators.Docs/**

正式建置與預覽：

```bash
npm run docs:build
npm run docs:preview
```

輸出目錄為 **`.vitepress/dist`**。

## 相關連結

| 連結 | 說明 |
|------|------|
| [Generator repo](https://github.com/MvvmAIO/Prism.SourceGenerators) | 套件與 README |
| [Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples) | Avalonia、WPF、MAUI 與 Uno 範例 |
| [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) | 索引文件 |

## 授權條款

MIT — 請參閱 [LICENSE](LICENSE)。
