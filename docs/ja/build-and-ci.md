---
title: ビルドと CI
description: ソリューション、Nuke ターゲット、バッジ、テスト成果物。
---

::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::

# ビルドと CI

## ソリューション

| ファイル | 内容 |
|----------|------|
| **`Prism.SourceGenerators.slnx`** | 製品プロジェクト（ジェネレータ、Core、Bcl）。 |
| **`Prism.SourceGenerators.Full.slnx`** | 製品 + Nuke。ドキュメントは **Prism.SourceGenerators.Docs**（別リポジトリ）。 |
| **`build.slnx`** | ビルドオーケストレーションのみ。 |

## ローカルコマンド（Nuke）

**Prism.SourceGenerators** リポジトリのルートで実行：

```bash
# CI 相当：クリーン、復元、コンパイル、テスト
dotnet run --project build/_build.csproj -- --target Ci --configuration Release

# NuGet パック
dotnet run --project build/_build.csproj -- --target Pack --configuration Release --version 0.2.0

# NuGet.org へ公開
dotnet run --project build/_build.csproj -- --target Publish --configuration Release --version 0.2.0 --nuget-api-key <NUGET_API_KEY>
```

## ドキュメントサイト（本リポジトリ）

| タスク | コマンド |
|--------|----------|
| 開発サーバー | `npm install` の後 `npm run docs:dev` |
| 本番ビルド | `npm run docs:build` |
| プレビュー | `npm run docs:preview` |

ローカル URL：`http://localhost:5173/Prism.SourceGenerators.Docs/`

**GitHub Actions**（`.github/workflows/github-pages.yml`）は PR で `npm ci` と `npm run docs:build` を実行し、**`main`** への push で GitHub Pages にデプロイします。

## CI のシグナル

- README の **`.NET` ワークフローバッジ** は **`master`** の健全性。
- **`Tests` バッジ** は直近の成功 / 失敗 / スキップ件数（`.github/badges/tests.json`）。
- ワークフローは **`test-results`**（`.trx`）をアップロード。

## 次へ

- [コントリビュート](/ja/contributing)
- [診断リファレンス](/ja/diagnostics/reference)
