---
title: 診断リファレンス
description: MvvmAIO.Prism.SourceGenerators の PSG 診断 ID、深刻度、修正の手引き。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# 診断リファレンス

コンパイラ診断は **`master`** の **`Prism.SourceGenerators/Diagnostics/DiagnosticDescriptors.cs`** で定義されています。下表の **Title** は記述子と一致します。プレースホルダを含む全文はコンパイラ **message** を参照してください。

::: info ヘルプリンク
記述子は製品 README の診断節を指す場合があります。**人間向けの索引としては本ページを推奨**します。

:::

## PSG0001–PSG0004 — `partial` が必要

| ID | 深刻度 | Title（英語原文） |
|----|--------|-------------------|
| **PSG0001** | Error | Class with `[ObservableProperty]` members must be partial |
| **PSG0002** | Error | Class with command generation attribute must be partial |
| **PSG0003** | Error | Property with `[ObservableProperty]` must be partial |
| **PSG0004** | Error | Class with `[BindableBase]` must be partial |
| **PSG0005** | Error | Class with `[BindableValidator]` must be partial |
| **PSG0006** | Error | `[BindableValidator]` is only supported on classes |

**コードフィックス：** **PSG0001–PSG0005** は IDE で **MakePartial**（**Ctrl+.** / **Alt+Enter**）。

## PSG1001–PSG1002 — コマンドメソッドのシグネチャ

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG1001** | Error | Invalid `[DelegateCommand]` method signature |
| **PSG1002** | Error | Invalid `[AsyncDelegateCommand]` method signature |

詳細は [DelegateCommand](/ja/generators/delegate-command) と [AsyncDelegateCommand](/ja/generators/async-delegate-command)。

## PSG2001–PSG2006 — 名前、ハンドラ、シグネチャ

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG2001** | Warning | Catch handler not found |
| **PSG2002** | Warning | Catch handler has incompatible signature |
| **PSG2003** | Warning | CanExecute member not found |
| **PSG2004** | Warning | Observed property not found |
| **PSG2005** | Warning | `[NotifyCanExecuteChangedFor]` command not found |
| **PSG2006** | Warning | CanExecute member has incompatible signature |

## PSG3002 — AsyncDelegateCommand パッケージ

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG3002** | Error | AsyncDelegateCommand package required for Prism prior to 9.0 |

**`MvvmAIO.Prism.SourceGenerators`** を入れる。**Prism.Core 8.1.97** では **`MvvmAIO.Prism.Bcl.Commands`** も追加するか、**Prism 9+** に上げる。

## PSG4001–PSG4002 — コンテナ登録

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG4001** | Warning | ServiceType is not assignable from implementation type |
| **PSG4002** | Warning | ViewModelType could not be resolved |

[コンテナ登録](/ja/generators/container-registration) を参照。

## PSG5001 — バリデーション

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG5001** | Warning | `[NotifyDataErrorInfo]` requires `BindableValidator` base type |

`[NotifyDataErrorInfo]` は型が `BindableValidator` を継承しているか、`[BindableValidator]` を付与している場合のみ有効です。そうでない場合、生成された setter は `ValidateProperty` を呼び出しません。詳細は [BindableValidator](/ja/generators/bindable-validator) を参照。

## PSG6001 — partial property の提案

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG6001** | Info | Use partial property for `[ObservableProperty]` (C# 13+) |

**コードフィックス：** C# 13+ が有効な場合、フィールドベースの `[ObservableProperty]` を partial property に変換します。

## PSG0007–PSG0008 — ナビゲーションとダイアログ

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG0007** | Error | Class with `[NavigationAware]` must be partial |
| **PSG0008** | Error | Class with `[DialogAware]` must be partial |

**コードフィックス：** IDE で **MakePartial** が利用可能です。

詳細は [NavigationAware](/ja/generators/navigation-aware) と [DialogAware](/ja/generators/dialog-aware)。

## PSG7001–PSG7005 — リージョンナビゲーションコマンド

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG7001** | Error | IRegionManager member not found |
| **PSG7002** | Error | Region is required for `[NavigateCommand]` |
| **PSG7003** | Error | Target is required for `[NavigateCommand]` |
| **PSG7004** | Error | `[NavigateOnChanged]` requires `[ObservableProperty]` |
| **PSG7005** | Error | TargetMember is required for `[NavigateOnChanged]` |

## PSG7101–PSG7102 — ダイアログサービスコマンド

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG7101** | Error | IDialogService member not found |
| **PSG7102** | Error | Name is required for `[ShowDialogCommand]` |

## PSG7006–PSG7008 — `[FromNavigationParameter]`

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG7006** | Error | `[FromNavigationParameter]` can only be applied to fields or properties |
| **PSG7007** | Warning | `[FromNavigationParameter]` requires `[ObservableProperty]` |
| **PSG7008** | Error | `[FromNavigationParameter]` key cannot be empty |

詳細は [NavigationAware](/ja/generators/navigation-aware)。

## PSG7103–PSG7105 — `[FromDialogParameter]`

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG7103** | Error | `[FromDialogParameter]` can only be applied to fields or properties |
| **PSG7104** | Warning | `[FromDialogParameter]` requires `[ObservableProperty]` |
| **PSG7105** | Error | `[FromDialogParameter]` key cannot be empty |

詳細は [DialogAware](/ja/generators/dialog-aware)。

## 次へ

- [ジェネレータ概要](/ja/generators/)
- [コントリビュート](/ja/contributing)
