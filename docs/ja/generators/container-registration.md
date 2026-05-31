---
title: コンテナ登録
description: IContainerRegistry 呼び出しを生成する属性。
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# コンテナ登録

**`ContainerRegistryRegistrationGenerator`** が登録属性を集め、**`PrismRegistrationExtensions.g.cs`** を生成します。拡張メソッドは **Prism 8** および **Prism 9+** と整合する **`IContainerRegistry`** API を呼びます。

## アプリでの呼び出し

合成ルート（例：**`RegisterTypes`**）から生成された拡張を呼び、**`IContainerRegistry`** を渡します。正確なメソッド名は生成結果に従います。成功ビルド後、**obj** 出力の **`PrismRegistrationExtensions.g.cs`** を開いて確認するか、サンプルと比較してください。

::: info サンプル
**[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** に Avalonia + Prism 8/9 の動作例があります。

:::
## 属性（要約）

| 属性 | 目的 |
|------|------|
| **`[Register]`**、**`[Register<T>]`** | 一般登録、**`PrismRegistrationLifetime`**（Transient / Scoped / Singleton）。 |
| **`[RegisterSingleton]`**、**`[RegisterSingleton<T>]`** | シングルトン短縮形。 |
| **`[RegisterScoped]`**、**`[RegisterScoped<T>]`** | スコープ寿命。 |
| **`[RegisterTransient]`**、**`[RegisterTransient<T>]`** | トランジェント寿命。 |
| **`[RegisterForNavigation]`**、**`[RegisterForNavigation<TViewModel>]`** | **`RegisterForNavigation<TView, TViewModel>(name)`**。 |
| **`[RegisterDialog]`**、**`[RegisterDialog<TViewModel>]`** | **`ViewModelType`** 付きダイアログ登録。 |
| **`[RegisterDialogWindow]`** | ダイアログウィンドウ登録。 |

よく使うプロパティ：**`Name`**、**`ServiceType`**、**`IfNotRegistered`**、**`ViewModelType`**（必要な場合）。

## 出力順（決定的）

ナビゲーション登録を**ダイアログより先**に並べ、その後寿命ベースの登録を並べ替え、ビルド間で順序を安定させます。

## 診断

| ID | 状況 |
|----|------|
| **PSG4001** | **`ServiceType`** が実装型から代入可能でない。 |
| **PSG4002** | ナビ/ダイアログの **`ViewModelType`** を解決できない。登録をスキップ。 |

## 例（ナビゲーション）

```csharp
namespace Demo;

public sealed partial class MyVm { }

[Prism.SourceGenerators.RegisterForNavigation(ViewModelType = typeof(Demo.MyVm), Name = "mine")]
public sealed partial class MyView { }
```

**`RegisterForNavigation<MyView, MyVm>("mine")`** 形式の呼び出しが生成されます（厳密な形は製品テスト参照）。

## 関連

- [アーキテクチャ概要](/ja/architecture/overview)
- [診断リファレンス](/ja/diagnostics/reference)
