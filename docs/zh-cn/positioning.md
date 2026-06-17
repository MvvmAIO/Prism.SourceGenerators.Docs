---
title: 生态定位
description: MvvmAIO.Prism.SourceGenerators 与 CommunityToolkit.Mvvm、Prism 商业工具的关系。
---

# 生态定位

**MvvmAIO.Prism.SourceGenerators** 是面向 **Prism** MVVM 的 **MIT 开源** Roslyn 源生成器包，由 MvvmAIO 社区维护，**不隶属于** Prism Library 商业产品。

## 适用人群

| 用户 | 价值 |
|------|------|
| **Prism 8.1.97（MIT）** | 在不离开 `BindableBase` / `DelegateCommand` 的前提下获得现代化生成器体验。 |
| **Prism 9 社区许可** | 与 Prism 9 API 对齐；Prism 8 才需要可选的 `MvvmAIO.Prism.Bcl.Commands`。 |
| **对比 MVVM 工具包** | 保留 Prism 语义，而非迁移到 `ObservableObject` / `RelayCommand`。 |

## 与 CommunityToolkit.Mvvm 对比

| 维度 | CommunityToolkit.Mvvm | 本包 |
|------|----------------------|------|
| 基类 | `ObservableObject` | `BindableBase` 或 `[BindableBase]` |
| 命令 | `RelayCommand` | `DelegateCommand` / `AsyncDelegateCommand` |
| Prism 集成 | 无 | `[Register]`、`[NavigationAware]`、`[DialogAware]` 等 |
| 许可 | MIT | MIT |
| partial 属性 | 支持 | 支持；**PSG6001** 可建议字段迁移为 partial 属性 |

未使用 Prism 时选 **Toolkit**；已用 Prism 且希望 Toolkit 式体验时选 **本包**。

## Prism 商业工具（背景）

Prism 9+ 采用 **社区 / 商业** 双许可。官方曾描述面向付费档位的 **配套生产力工具**（分析器、源生成器等）。

**MvvmAIO.Prism.SourceGenerators** 是独立的 **MIT 开源**方案，侧重：

- 仅源生成器（不做 IL weaving）
- 同时支持 Prism 8 与 Prism 9
- 在 **NuGet.org** 发布

不与任何商业产品做功能对等承诺；选型时请对照各自的发布说明与文档。

## 设计原则

1. **保留 Prism 语义** — setter 走 `SetProperty`，命令使用 Prism 类型。
2. **多 Roslyn 矩阵** — 单个 NuGet 包按 SDK 选择分析器。
3. **可追踪诊断** — 所有 **PSG** 规则见 [诊断参考](/zh-cn/diagnostics/reference)。

## 下一步

- [快速开始](/zh-cn/getting-started)
- [示例](/zh-cn/samples)
- [源生成器总览](/zh-cn/generators/)
