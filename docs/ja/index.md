---
title: 概要
description: Prism 向けコンパイル時 MVVM — MvvmAIO.Prism.SourceGenerators。
---

# Prism のコンパイル時 MVVM

**MvvmAIO.Prism.SourceGenerators** は、**BindableBase** の意味論を保ちながら Observable・コマンド・コンテナ登録のボイラープレートを削減します。

!!! success "正典ドキュメント"
    **このサイト**がプロジェクトの**権威あるマニュアル**です。GitHub **README**、**GitHub Wiki**、DeepWiki より深い説明と構成はここを優先してください。**[サイトについて](about-this-site.md)** で各チャネルの役割を説明しています。

!!! note "言語 / Languages"
    **[English](../)** · **[简体中文](../zh-cn/)** · **[日本語](.)**

## 主な機能

| 領域 | 内容 |
|------|------|
| **Observable** | フィールド／C# 13+ partial property の `[ObservableProperty]` など。 |
| **Commands** | `[DelegateCommand]` / `[AsyncDelegateCommand]`、`ValueTask` 対応。 |
| **Registration** | `IContainerRegistry` 向け登録コードの生成。 |
| **Diagnostics** | **PSG** とコードフィックス（**MakePartial** など）。 |

## 次に読む

| ページ | 内容 |
|--------|------|
| [はじめに](getting-started.md) | インストール、partial、Prism 8/9。 |
| [ジェネレータ概要](generators/index.md) | トピック別リファレンス（日本語本文）。 |
| [診断リファレンス](diagnostics/reference.md) | **PSG** 一覧。 |
| [アーキテクチャ概要](architecture/overview.md) | レイアウトと Roslyn マルチターゲット。 |
| [ビルドと CI](build-and-ci.md) | `slnx`、Nuke。 |
| [サンプル](samples.md) | **Prism.SourceGenerators.Samples**。 |

## NuGet

- [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators)
- [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands)

## ドキュメント更新

**最終更新：** 2026-05-16 13:24:06 +0800  
**コミット：** `12e9516` - 内部リンク修正 - 診断リファレンスページから .md 拡張子を削除

---

## その他（非正典）

- [GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators)
- [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) — 探索用。**詳細は本サイトを優先**。

_このサイトは [.NET 10](https://dotnet.microsoft.com/) と **NuStreamDocs** でビルドしています。_
