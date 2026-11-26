# Prism.SourceGenerators.Docs

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md)

**[MvvmAIO.Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** 的静态文档站点，基于 **[VitePress](https://vitepress.dev/)** 构建（支持 Markdown、本地搜索与语法高亮）。

## 在线站点

**https://mvvmaio.github.io/Prism.SourceGenerators.Docs/**

如果站点尚未启用，请在仓库 **Settings → Pages** 中将发布源设为 **GitHub Actions**。

## 多语言

- **English** — `docs/` 下的默认文档树
- **简体中文** — `docs/zh-cn/`（URL 路径 `/zh-cn/`）
- **日本語** — `docs/ja/`（URL 路径 `/ja/`）

导航与侧边栏定义在 **`.vitepress/config.mts`**，响应式样式微调位于 **`.vitepress/theme/custom.css`**。

## 本地开发

```bash
npm install
npm run docs:dev
```

访问 **http://localhost:5173/Prism.SourceGenerators.Docs/**

生产构建与预览：

```bash
npm run docs:build
npm run docs:preview
```

构建产物输出至 **`.vitepress/dist`**。

## 相关链接

| 链接 | 说明 |
|------|------|
| [Generator repo](https://github.com/MvvmAIO/Prism.SourceGenerators) | 主包与 README |
| [Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples) | Avalonia 示例 |
| [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) | 索引文档 |

## 许可证

MIT — 见 [LICENSE](LICENSE)。
