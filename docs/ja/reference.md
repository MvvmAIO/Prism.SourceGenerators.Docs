---
title: 参考・リンク
description: 外部リソース、本サイト内の案内、ビルドコマンド。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# 参考・リンク

以下を本文とあわせて使ってください。**意味論・診断・アーキテクチャ**は本サイトのページを正とし、サードパーティのミラーは補助です。

::: info 言語
[English](/ja/reference) · [简体中文](/ja/reference)

:::
---

## クイックリンク

| リソース | 内容 |
|----------|------|
| **[Prism.SourceGenerators（GitHub）](https://github.com/MvvmAIO/Prism.SourceGenerators)** | ソース、Issue、PR、CI。 |
| **[GitHub Wiki](https://github.com/MvvmAIO/Prism.SourceGenerators/wiki)**（[`wiki/`](https://github.com/MvvmAIO/Prism.SourceGenerators/tree/master/wiki)） | 短いトピックメモ。**正典は本サイト**。 |
| **[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)** | 本サイトのリポジトリ。 |
| **[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** | Avalonia サンプル（Prism 8 / 9）。 |
| **[DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators)** | AI インデックス。**挙動や診断文言の契約にはしない**。 |

---

## 本サイト内

| トピック | ページ |
|----------|--------|
| ジェネレータ | [概要](/ja/generators/) |
| **PSG** 診断 | [診断リファレンス](/ja/diagnostics/reference) |
| ビルドと CI | [ビルドと CI](/ja/build-and-ci) |
| 貢献 | [コントリビュート](/ja/contributing) |
| Avalonia の実行サンプル | [サンプル](/ja/samples) |

---

## ジェネレータリポジトリのレイアウト

```
Prism.SourceGenerators/
Prism.SourceGenerators.Roslyn4001/
Prism.SourceGenerators.Roslyn4031/
Prism.SourceGenerators.Roslyn4120/
Prism.SourceGenerators.Roslyn5000/
Prism.SourceGenerators.Core/
Prism.Bcl.Commands/
```

---

## Build と Nuke

**Prism.SourceGenerators** のルートで：

```bash
dotnet build Prism.SourceGenerators.slnx
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

---

## CI

- **`.NET`** ワークフローバッジは **`master`** の健全性。
- **`Tests`** バッジは直近の成功 / 失敗 / スキップ。
- **`.trx`** 成果物がアップロードされます。

---

## README、Wiki、本サイト

GitHub **README**（各言語）と **GitHub Wiki** は**短い入口**です。**表・相互リンク・多言語の長文**は本サイトで管理し、役割の整理は **[サイトについて](/ja/about-this-site)** を参照してください。
