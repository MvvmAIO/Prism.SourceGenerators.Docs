---
title: 构建与 CI
description: 解决方案、Nuke 目标、徽章与测试产物。
---

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

## CI 信号

- README 上的 **`.NET` 工作流徽章** 反映 **`master`** 流水线健康度。
- **`Tests` 徽章** 展示最近一次运行的通过 / 失败 / 跳过数量（见生成器仓库 `.github/badges/tests.json`）。
- 工作流上传 **`test-results`**（`.trx`），便于在 IDE 或 trx 查看器中分析。

## 下一步

- [贡献指南](../contributing.md)
- [诊断参考](../diagnostics/reference.md)
