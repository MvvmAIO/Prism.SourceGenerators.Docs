---
title: ビルドと CI
description: ソリューション、Nuke ターゲット、バッジ、テスト成果物。
---

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

## CI のシグナル

- README の **`.NET` ワークフローバッジ** は **`master`** の健全性。
- **`Tests` バッジ** は直近の成功 / 失敗 / スキップ件数（`.github/badges/tests.json`）。
- ワークフローは **`test-results`**（`.trx`）をアップロード。

## 次へ

- [コントリビュート](../contributing.md)
- [診断リファレンス](../diagnostics/reference.md)
