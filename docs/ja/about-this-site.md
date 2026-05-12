---
title: このサイトについて
description: README、GitHub Wiki、DeepWiki、サンプルとの役割分担。
---

# このサイトについて

**MvvmAIO.Prism.SourceGenerators** の**正典となる製品マニュアル**です。リポジトリは **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)**、GitHub Pages で公開します。

## 他の情報源との関係

| 表面 | 役割 |
|------|------|
| **このサイト** | 構成・ジェネレータ意味論・診断・アーキテクチャ・ビルド・コントリビューション。**深い説明はここを優先**。 |
| **[GitHub README](https://github.com/MvvmAIO/Prism.SourceGenerators/blob/master/README.md)**（[簡体字中国語 README](https://github.com/MvvmAIO/Prism.SourceGenerators/blob/master/README.zh-CN.md) / [日本語 README](https://github.com/MvvmAIO/Prism.SourceGenerators/blob/master/README.ja.md)） | リポジトリの**短い**概要とコピペ例。 |
| **[GitHub Wiki](https://github.com/MvvmAIO/Prism.SourceGenerators/wiki)**（[`wiki/`](https://github.com/MvvmAIO/Prism.SourceGenerators/tree/master/wiki)） | **短い**トピック別メモ（中文中心）。**診断や API の契約ではない**。 |
| **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** | リポジトリの AI インデックス。**API や診断文言の契約にはしない**。 |
| **サンプル** | 実行可能なアプリ。[Samples](samples.md)。 |

コンパイラ出力の**契約**は製品側の **`DiagnosticDescriptors.cs`**。人向け索引は [診断リファレンス](diagnostics/reference.md)。

## 言語

**日本語**ページは英語版と同じ構成（アーキテクチャ、ジェネレータ、診断、ビルドなど）です。未訳は **[English](../)** を参照してください。

## ドキュメントへの貢献

**Prism.SourceGenerators.Docs**（Markdown + `mkdocs.yml`）。製品コードは **Prism.SourceGenerators**。[コントリビュート](contributing.md)。
