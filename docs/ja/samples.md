---
title: サンプル
description: MvvmAIO.Prism.SourceGenerators を使う Avalonia サンプル。
---

# サンプル

実行可能なアプリは **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** にあります。

| 観点 | メモ |
|------|------|
| **Prism 8** | **`AsyncDelegateCommand`** に **`MvvmAIO.Prism.Bcl.Commands`** が必要な例。 |
| **Prism 9** | 組み込みの非同期コマンド型を利用。 |
| **Avalonia** | デモの UI スタック。ジェネレータの使い方は UI 非依存。 |

リポジトリをクローンし、その中のソリューションを開くと、**ObservableProperty**、**コマンド**、**登録**を端到端で追えます。

## リポジトリ構成

- **`Prism.SourceGenerators.Samples.slnx`** — Visual Studio **17.13+** または Rider で開く（`.slnx` 対応が必要）。
- **`Prism.SourceGenerators.Samples.Prism8`** — ターゲット **`net8.0`**、Prism 8。**`AsyncDelegateCommand`** には **`MvvmAIO.Prism.Bcl.Commands`**。
- **`Prism.SourceGenerators.Samples.Prism9`** — ターゲット **`net10.0`**、Prism 9 と組み込み非同期コマンド。**Validation**（`BindableValidator`、`[NotifyDataErrorInfo]`、DataAnnotations）あり。

## ビルド

**Prism 9** 用に **.NET 10 SDK**、**`net8.0`** 用に **.NET 8** SDK/ランタイムが必要です。

```bash
git clone https://github.com/MvvmAIO/Prism.SourceGenerators.Samples.git
cd Prism.SourceGenerators.Samples
dotnet build Prism.SourceGenerators.Samples.slnx
```

## ローカルジェネレータと NuGet

**[Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators)** を**隣接フォルダー**（`../Prism.SourceGenerators`）にクローンすると、**`Directory.Build.props`** によりサンプルは **`MvvmAIO.Prism.SourceGenerators`** NuGet ではなく**プロジェクト参照**に切り替わります（ジェネレータ開発向け）。上書きと詳細はサンプルリポジトリの **`build/README-LocalSourceGenerators.md`**（`UseLocalPrismSourceGenerators`）。

## 次へ

- [はじめに](getting-started.md)
- [コンテナ登録](generators/container-registration.md)
