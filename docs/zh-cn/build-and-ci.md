---
title: 构建与 CI
description: 解决方案、Nuke 目标、徽章与测试产物。
---

::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::

# 构建与 CI

## 解决方案

| 文件 | 内容 |
|------|------|
| **`Prism.SourceGenerators.slnx`** | 主产品工程（生成器、Core、Bcl）。 |
| **`Prism.SourceGenerators.Full.slnx`** | 产品 + Nuke；文档站目前在 **Prism.SourceGenerators.Docs**（独立仓库）。 |
| **`build.slnx`** | 仅构建编排工程。 |

## 本地命令（Nuke）

在 **Prism.SourceGenerators** 仓库根目录执行：

```bash
# 类 CI：清理、还原、编译、测试
dotnet run --project build/_build.csproj -- --target Ci --configuration Release

# 打包 NuGet
dotnet run --project build/_build.csproj -- --target Pack --configuration Release --version 0.2.0

# 发布到 NuGet.org
dotnet run --project build/_build.csproj -- --target Publish --configuration Release --version 0.2.0 --nuget-api-key <NUGET_API_KEY>
```

## 文档站（本站仓库）

| 任务 | 命令 |
|------|------|
| 开发服务器 | `npm install` 后 `npm run docs:dev` |
| 生产构建 | `npm run docs:build` |
| 预览构建 | `npm run docs:preview` |

本地开发地址：`http://localhost:5173/Prism.SourceGenerators.Docs/`

**GitHub Actions**（`.github/workflows/github-pages.yml`）在 PR 上运行 `npm ci` 与 `npm run docs:build`；推送到 **`main`** 后部署 GitHub Pages。

## CI 信号

- README 上的 **`.NET` 工作流徽章** 反映 **`master`** 流水线健康度。
- **`Tests` 徽章** 展示最近一次运行的通过 / 失败 / 跳过数量（见生成器仓库 `.github/badges/tests.json`）。
- 工作流上传 **`test-results`**（`.trx`），便于在 IDE 或 trx 查看器中分析。

## 下一步

- [贡献指南](/zh-cn/contributing)
- [诊断参考](/zh-cn/diagnostics/reference)
