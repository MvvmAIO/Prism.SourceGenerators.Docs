---
title: Roslyn ターゲットと NuGet
description: Roslyn* プロジェクトが複数ある理由と、アプリが参照すべきパッケージ。
---

# Roslyn ターゲットとパッケージ

## なぜ `Prism.SourceGenerators.Roslyn*` が複数あるのか

Roslyn の **公開 API** と **言語機能** はコンパイラのメジャーごとに進みます。製品は **複数のジェネレータアセンブリ** を出荷し、それぞれ特定の Roslyn に対してビルドし、そのリリースラインが期待する **最低コンパイラ** に合う NuGet を届けます。

下表は典型対応です（**フォルダ名は例** — 実際の集合は **`master`** のリポジトリを確認してください）。

| プロジェクトフォルダ | 意図 |
|----------------------|------|
| `Roslyn4001` | Roslyn 4.0.x の古い VS / SDK。 |
| `Roslyn4031` | 4.x 中期。 |
| `Roslyn4120` | 4.12 世代の API。 |
| `Roslyn5000` | Roslyn 5 / 現行 C# フロンティア。 |

**アプリからこれらのプロジェクトを直接参照しません。** **MvvmAIO.Prism.SourceGenerators** パッケージに、その版が宣言する SDK 範囲に合ったプリコンパイル済みジェネレータが含まれます。

## アプリで参照するパッケージ

- **`MvvmAIO.Prism.SourceGenerators`** — アナライザ + ジェネレータ + **MvvmAIO.Prism.Core**（属性）。
- **`MvvmAIO.Prism.Bcl.Commands`** — **Prism.Core 8.1.97** で **`AsyncDelegateCommand`** が必要な場合に任意。[診断リファレンス](../diagnostics/reference.md) の **PSG3002** と [AsyncDelegateCommand](../generators/async-delegate-command.md) を参照。

## 次へ

- [アーキテクチャ概要](overview.md)
- [はじめに](../getting-started.md)
