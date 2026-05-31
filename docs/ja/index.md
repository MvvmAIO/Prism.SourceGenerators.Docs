---
layout: home
title: 概要
description: Prism 向けコンパイル時 MVVM — MvvmAIO.Prism.SourceGenerators。

hero:
  name: Prism.SourceGenerators
  text: Prism のコンパイル時 MVVM
  tagline: MvvmAIO.Prism.SourceGenerators は、BindableBase の意味論を保ちながら Observable・コマンド・コンテナ登録のボイラープレートを削減します。
  actions:
    - theme: brand
      text: はじめに
      link: /ja/getting-started
    - theme: alt
      text: ジェネレータ
      link: /ja/generators/
    - theme: alt
      text: 診断
      link: /ja/diagnostics/reference

features:
  - title: Observable
    details: フィールド／C# 13+ partial property の [ObservableProperty] など。
  - title: Commands
    details: "[DelegateCommand] / [AsyncDelegateCommand]、ValueTask 対応。"
  - title: Registration
    details: IContainerRegistry 向け登録コードの生成。
  - title: Diagnostics
    details: PSG とコードフィックス（MakePartial など）。
---

::: tip 正典ドキュメント
**このサイト**がプロジェクトの**権威あるマニュアル**です。GitHub **README**、**GitHub Wiki**、DeepWiki より深い説明と構成はここを優先してください。**[サイトについて](/ja/about-this-site)** で各チャネルの役割を説明しています。
:::

::: info 言語 / Languages
**[English](/)** · **[简体中文](/zh-cn/)** · **[日本語](/ja/)**
:::

## 次に読む

| ページ | 内容 |
|--------|------|
| [はじめに](/ja/getting-started) | インストール、partial、Prism 8/9。 |
| [ジェネレータ概要](/ja/generators/) | トピック別リファレンス（日本語本文）。 |
| [診断リファレンス](/ja/diagnostics/reference) | **PSG** 一覧。 |
| [アーキテクチャ概要](/ja/architecture/overview) | レイアウトと Roslyn マルチターゲット。 |
| [ビルドと CI](/ja/build-and-ci) | slnx、Nuke。 |
| [サンプル](/ja/samples) | **Prism.SourceGenerators.Samples**。 |

## NuGet

- [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators)
- [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands)

## その他（非正典）

- [GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators)
- [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) — 探索用。**詳細は本サイトを優先**。
