---
title: ソースジェネレータ
description: Prism MVVM 向けソースジェネレータ機能の索引。
---

# ソースジェネレータ

**MvvmAIO.Prism.SourceGenerators** はコンパイル時に **partial** 型を拡張します。属性は **`MvvmAIO.Prism.Core`**（名前空間 **`Prism.SourceGenerators`**）にあります。

!!! tip "partial 型"
    生成メンバをマージする宣言は **`partial`** が必要です。**PSG0001–PSG0004** が典型ミスをカバーし、4 つとも **MakePartial** コードフィックスがあります。

## トピック

| トピック | 要約 |
|----------|------|
| [ObservableProperty](observable-property.md) | フィールドと **C# 13+** partial プロパティ、**`PropertyAccess`**、**`OnChanging` / `OnChanged`**。 |
| [通知と転送](notifications.md) | **`[NotifyPropertyChangedFor]`**、**`[NotifyCanExecuteChangedFor]`**、**`[property: …]`** 転送。 |
| [DelegateCommand](delegate-command.md) | 同期、**`CanExecute`**、**`Task`**、**`ValueTask`**。 |
| [AsyncDelegateCommand](async-delegate-command.md) | 並列、**`Catch`**、**`CancelAfter`**、**`ObservesCanExecute`**、Prism 8 と 9 のパッケージ差。 |
| [ObservesProperty](observes-property.md) | プロパティ変更時に **`CanExecute`** を再評価。 |
| [BindableBase](bindable-base.md) | Prism **`BindableBase`** を継承しない型への **INPC**。 |
| [コンテナ登録](container-registration.md) | **`Register*`**、**`RegisterForNavigation`**、**`RegisterDialog`**、**`IContainerRegistry`** 呼び出し生成。 |

## 診断

すべてのコンパイラ ID は **[診断リファレンス](../diagnostics/reference.md)** にまとめています。

## 次へ

- [アーキテクチャ概要](../architecture/overview.md)
- [はじめに](../getting-started.md)
