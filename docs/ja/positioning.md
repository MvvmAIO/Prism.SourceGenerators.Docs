---
title: エコシステム上の位置づけ
description: MvvmAIO.Prism.SourceGenerators と CommunityToolkit.Mvvm、Prism 商用ツールの関係。
---

# エコシステム上の位置づけ

**MvvmAIO.Prism.SourceGenerators** は **Prism** MVVM 向けの **MIT オープンソース** Roslyn ソースジェネレータです。MvvmAIO コミュニティが保守しており、Prism Library の商用製品とは **無関係**です。

## 対象ユーザー

| ユーザー | メリット |
|----------|----------|
| **Prism 8.1.97（MIT）** | `BindableBase` / `DelegateCommand` を維持したままモダンな生成器 UX。 |
| **Prism 9 コミュニティライセンス** | Prism 9 API と整合。Prism 8 のみ `MvvmAIO.Prism.Bcl.Commands` が任意。 |
| **MVVM ツールキット比較** | Prism 型を捨てずに Toolkit 風の記述。 |

## CommunityToolkit.Mvvm との比較

| 項目 | CommunityToolkit.Mvvm | 本パッケージ |
|------|----------------------|--------------|
| 基底 | `ObservableObject` | `BindableBase` / `[BindableBase]` |
| コマンド | `RelayCommand` | `DelegateCommand` / `AsyncDelegateCommand` |
| Prism 連携 | なし | `[Register]`、`[NavigationAware]`、`[DialogAware]` など |
| ライセンス | MIT | MIT |

Prism を使わない場合は **Toolkit**。Prism を維持する場合は **本パッケージ**。

## Prism 商用ツール（参考）

Prism 9+ は **コミュニティ / 商用** のデュアルライセンスです。有料ティア向けの **生産性ツール**（アナライザ、ソースジェネレータなど）が公式に言及されています。

**MvvmAIO.Prism.SourceGenerators** は独立した **MIT** 実装で、次に焦点を当てます。

- ソースジェネレータのみ（IL weaving なし）
- Prism 8 と 9 の両対応
- **NuGet.org** 配布

商用製品との機能同等性は保証しません。選定時は各製品のリリースノートを参照してください。

## 次のステップ

- [はじめに](/ja/getting-started)
- [サンプル](/ja/samples)
- [ジェネレータ概要](/ja/generators/)
