---
title: ソースジェネレータ
description: Prism MVVM 向けソースジェネレータ機能の索引。
---

::: tip 言語 / Languages
このページは [English](/generators/) と [简体中文](/zh-cn/generators/) でもご覧いただけます。
:::

# ソースジェネレータ

**MvvmAIO.Prism.SourceGenerators** はコンパイル時に **partial** 型を拡張します。属性は **`MvvmAIO.Prism.Core`**（名前空間 **`Prism.SourceGenerators`**）にあります。

::: tip partial 型
生成メンバをマージする宣言は **`partial`** が必要です。**PSG0001–PSG0005** が典型ミスをカバーし、5 つとも **MakePartial** コードフィックスがあります。

:::

## トピック

| トピック | 要約 |
|----------|------|
| [ObservableProperty](/ja/generators/observable-property) | フィールドと **C# 13+** partial プロパティ、**`PropertyAccess`**、**`OnChanging` / `OnChanged`**。 |
| [通知と転送](/ja/generators/notifications) | **`[NotifyPropertyChangedFor]`**、**`[NotifyCanExecuteChangedFor]`**、**`[property: …]`** 転送。 |
| [DelegateCommand](/ja/generators/delegate-command) | 同期、**`CanExecute`**、**`Task`**、**`ValueTask`**。 |
| [AsyncDelegateCommand](/ja/generators/async-delegate-command) | 並列、**`Catch`**、**`CancelAfter`**、**`ObservesCanExecute`**、Prism 8 と 9 のパッケージ差。 |
| [ObservesProperty](/ja/generators/observes-property) | プロパティ変更時に **`CanExecute`** を再評価。 |
| [BindableBase](/ja/generators/bindable-base) | Prism **`BindableBase`** を継承しない型への **INPC**。 |
| [BindableValidator](/ja/generators/bindable-validator) | **`[BindableValidator]`** と **`[NotifyDataErrorInfo]`** で **`INotifyDataErrorInfo`** 検証サポートを生成。 |
| [コンテナ登録](/ja/generators/container-registration) | **`Register*`**、**`RegisterForNavigation`**、**`RegisterDialog`**、**`IContainerRegistry`** 呼び出し生成。 |
| [NavigationAware](/ja/generators/navigation-aware) | **`INavigationAware`** ライフサイクル；Prism 8 **`Prism.Regions`** / Prism 9 **`Prism.Navigation.Regions`**。 |
| [DialogAware](/ja/generators/dialog-aware) | **`IDialogAware`**；Prism 8 **`Prism.Services.Dialogs`** / Prism 9 **`Prism.Dialogs`**。 |
| [NavigateCommand (EN)](/generators/navigate-command) | **`IRegionManager.RequestNavigate`** コマンド生成（英語ドキュメント）。 |
| [ShowDialogCommand (EN)](/generators/show-dialog-command) | **`IDialogService.ShowDialog`** コマンド生成（英語ドキュメント）。 |

## 診断

すべてのコンパイラ ID は **[診断リファレンス](/ja/diagnostics/reference)** にまとめています。

## 次へ

- [アーキテクチャ概要](/ja/architecture/overview)
- [はじめに](/ja/getting-started)
- [RFC: Navigation & Dialog — advanced contracts (EN)](/rfc/navigation-dialog-advanced)
