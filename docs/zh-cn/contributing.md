---
title: 贡献指南
description: 向生成器或本站文档贡献代码的方式。
---
::: tip 语言 / Languages
本页另有 [English](/) 和 [日本語](/ja/) 版本。
:::


# 贡献指南

## 产品（生成器、Core、测试）

请遵循 **Prism.SourceGenerators** 仓库中的 **[CONTRIBUTING.md](https://github.com/MvvmAIO/Prism.SourceGenerators/blob/master/CONTRIBUTING.md)**：议题、分支、测试与代码风格。

## 文档（本站）

- 仓库：**[Prism.SourceGenerators.Docs](https://github.com/MvvmAIO/Prism.SourceGenerators.Docs)**  
- 内容：**`docs/`** 下 Markdown、**`.vitepress/config.mts`** 导航、可选 **`.vitepress/theme/custom.css`**。  
- 本地构建：在该仓库执行 **`dotnet run`**（参见该仓库 README）。

若修改了 **诊断 ID 或面向用户的提示文案**，请在同一产品 PR 中、或紧随其后更新 **[诊断参考](/zh-cn/diagnostics/reference)**，以保持本站与编译器输出一致。

## 下一步

- [关于本站](/zh-cn/about-this-site)
- [构建与 CI](/zh-cn/build-and-ci)
