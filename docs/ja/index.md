---
title: 概要
description: Prism 向けコンパイル時 MVVM — MvvmAIO.Prism.SourceGenerators。
---

# Prism のコンパイル時 MVVM

**MvvmAIO.Prism.SourceGenerators** は、**BindableBase** の意味論を保ちながら Observable・コマンド・コンテナ登録のボイラープレートを削減します。

!!! note "言語 / Languages"
    **[English](../)** · **[简体中文](../zh-cn/)** · **[日本語](.)**

## 主な機能

| 領域 | 内容 |
|------|------|
| **Observable** | フィールド／C# 13+ partial property の `[ObservableProperty]` など。 |
| **Commands** | `[DelegateCommand]` / `[AsyncDelegateCommand]`、`ValueTask` 対応。 |
| **Registration** | `IContainerRegistry` 向け登録コードの生成。 |
| **Diagnostics** | **PSG** とコードフィックス（**MakePartial** など）。 |

## NuGet

- [**MvvmAIO.Prism.SourceGenerators**](https://www.nuget.org/packages/MvvmAIO.Prism.SourceGenerators)
- [**MvvmAIO.Prism.Bcl.Commands**](https://www.nuget.org/packages/MvvmAIO.Prism.Bcl.Commands)

## さらに深く

- [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)
- [GitHub](https://github.com/MvvmAIO/Prism.SourceGenerators)

_このサイトは [.NET 10](https://dotnet.microsoft.com/) と **NuStreamDocs** でビルドしています。_
