---
title: 診断リファレンス
description: MvvmAIO.Prism.SourceGenerators の PSG 診断 ID、深刻度、修正の手引き。
---

# 診断リファレンス

コンパイラ診断は **`master`** の **`Prism.SourceGenerators/Diagnostics/DiagnosticDescriptors.cs`** で定義されています。下表の **Title** は記述子と一致します。プレースホルダを含む全文はコンパイラ **message** を参照してください。

!!! info "ヘルプリンク"
    記述子は製品 README の診断節を指す場合があります。**人間向けの索引としては本ページを推奨**します。

## PSG0001–PSG0004 — `partial` が必要

| ID | 深刻度 | Title（英語原文） |
|----|--------|-------------------|
| **PSG0001** | Error | Class with `[ObservableProperty]` members must be partial |
| **PSG0002** | Error | Class with command generation attribute must be partial |
| **PSG0003** | Error | Property with `[ObservableProperty]` must be partial |
| **PSG0004** | Error | Class with `[BindableBase]` must be partial |

**コードフィックス：** 4 件とも IDE で **MakePartial**（**Ctrl+.** / **Alt+Enter**）。

## PSG1001–PSG1002 — コマンドメソッドのシグネチャ

| ID | 深刻度 | Title |
|----|--------|-------|
| **PSG1001** | Error | Invalid `[DelegateCommand]` method signature |
| **PSG1002** | Error | Invalid `[AsyncDelegateCommand]` method signature |

詳細は [DelegateCommand](../generators/delegate-command.md) と [AsyncDelegateCommand](../generators/async-delegate-command.md)。

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

[コンテナ登録](../generators/container-registration.md) を参照。

## 次へ

- [ジェネレータ概要](../generators/index.md)
- [コントリビュート](../contributing.md)
