---
title: ソースジェネレータ
---

# ジェネレータの範囲

DeepWiki / README のジェネレータ節に概ね対応します。

!!! note "言語"
    [English](../generators/) · [简体中文](../zh-cn/generators/)

## ObservableProperty / Commands / 登録 / 診断

詳細は英語版 [Generators](../generators/) および [DeepWiki](https://deepwiki.com/MvvmAIO/Prism.SourceGenerators) を参照してください。

## コード例

```csharp
[ObservableProperty]
private string _title = "Hello";

[DelegateCommand(CanExecute = nameof(CanSubmit))]
private void Submit() { }
```

## PSG マトリクス

| ID | 意味 |
|----|------|
| PSG0001–PSG0004 | `partial` 不足 |
| PSG1001 / PSG1002 | execute シグネチャ不正 |
| PSG2001–PSG2006 | 記号解決・シグネチャ問題 |
| PSG3002 | `AsyncDelegateCommand` 不足 |
