---
title: アーキテクチャ概要
description: 複数リポジトリ、共有ジェネレータ、主要エントリポイント。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# アーキテクチャ概要

## リポジトリ

| リポジトリ | 役割 |
|------------|------|
| **[Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** | ソースジェネレータ、**MvvmAIO.Prism.Core** 属性、パッケージング、テスト、CI。 |
| **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** | 本静的サイト（VitePress）。 |
| **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | Avalonia サンプル（Prism 8 / 9）。 |

## Prism.SourceGenerators リポジトリ内の配置

```
Prism.SourceGenerators/           # 共有実装（.shproj / .projitems）
Prism.SourceGenerators.Core/    # MvvmAIO.Prism.Core として出荷される属性（アプリとアナライザが参照）
Prism.SourceGenerators.Roslyn*/ # コンパイラ版別ジェネレータ（NuGet 互換）
Prism.Bcl.Commands/             # 任意：Prism 8 向け AsyncDelegateCommand 互換
```

**共有**プロジェクトにジェネレータの大半があります。**Roslyn\*** は各 NuGet ラインが想定する **Roslyn バージョン** に合わせてビルドされ、消費者のツールチェーンに適したアセンブリが選ばれます。

## 主なジェネレータ（概念的）

| 領域 | 責務 |
|------|------|
| **Observable / コマンド** | `[ObservableProperty]`、`[DelegateCommand]`、`[AsyncDelegateCommand]` など。 |
| **コンテナ** | 登録属性 → `PrismRegistrationExtensions.g.cs` → `IContainerRegistry` 呼び出し。 |
| **BindableBase** | `[BindableBase]`：Prism `BindableBase` を継承しない型への **INPC** 生成。 |

各パイプラインは **Roslyn インクリメンタル生成**（`IIncrementalGenerator`）を使い、可能な限り **狭い属性プロバイダ** で再コンパイルコストを抑えます。

## 次へ

- [Roslyn ターゲットとパッケージ](/ja/architecture/roslyn-targeting)
- [ビルドと CI](/ja/build-and-ci)
