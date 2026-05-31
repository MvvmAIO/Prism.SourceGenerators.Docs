---
title: BindableValidator
description: "[BindableValidator] と [NotifyDataErrorInfo] で INotifyDataErrorInfo 検証サポートを生成。"
---
::: tip 言語 / Languages
このページは [English](/) と [简体中文](/zh-cn/) でもご覧いただけます。
:::


# `[BindableValidator]` と検証

`BindableValidator` は **`INotifyPropertyChanged`** と **`INotifyDataErrorInfo`** を同時に実装する抽象基底クラスで、`System.ComponentModel.DataAnnotations` によって支えられています。ジェネレータは 2 通りの方法で組み込みます。

---

## 方法 A — `BindableValidator` を直接継承

`BindableValidator` を継承し、プロパティに `[ObservableProperty]` + `[NotifyDataErrorInfo]` を付与します。ジェネレータは各 setter に `ValidateProperty(value, nameof(Property))` を自動で挿入します。

```csharp
public partial class LoginViewModel : BindableValidator
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "ユーザー名は必須です。")]
    [MinLength(2, ErrorMessage = "2 文字以上必要です。")]
    public partial string Username { get; set; } = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "メールアドレスは必須です。")]
    [EmailAddress(ErrorMessage = "有効なメールアドレスを入力してください。")]
    public partial string Email { get; set; } = "";
}
```

---

## 方法 B — `[BindableValidator]` 属性を使用

既に基底クラスがある（またはジェネレータにすべて任せたい）クラスには `[BindableValidator]` を付与します：

- 型に**宣言された基底がない**（`object` のみ）場合、生成された partial は `BindableValidator` を継承します。
- 型が**既に基底を持つ**場合、ジェネレータは `INotifyDataErrorInfo` と検証ヘルパーを直接 partial に挿入し、既存の `INotifyPropertyChanged` を再利用します。

型は **`partial`** である必要があります（**PSG0005**）。非クラス型（struct、interface 等）は **PSG0006** を報告します。

```csharp
[BindableValidator]
public partial class ProfileViewModel
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "表示名は必須です。")]
    [MaxLength(20, ErrorMessage = "20 文字以内で入力してください。")]
    public partial string DisplayName { get; set; } = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Range(1, 120, ErrorMessage = "年齢は 1～120 の範囲で入力してください。")]
    public partial int Age { get; set; }
}
```

型に明示的な基底型がない場合、ジェネレータはその partial が `BindableValidator` を継承するように生成します：

```csharp
// 生成コード（簡略）
public partial class ProfileViewModel : Prism.SourceGenerators.BindableValidator { }
```

`ValidateProperty`、`HasErrors` などのメンバはすべて `BindableValidator` から自動的に提供されるため、手書きが不要です。

---

## クラスレベルの `[NotifyDataErrorInfo]`

`[NotifyDataErrorInfo]` を**クラス**に付与すると、そのクラスのすべての生成プロパティに対して検証をまとめて有効化できます：

```csharp
[NotifyDataErrorInfo]
public partial class RegisterViewModel : BindableValidator
{
    [ObservableProperty]
    [Required]
    public partial string Username { get; set; } = "";

    [ObservableProperty]
    [EmailAddress]
    public partial string Email { get; set; } = "";
}
```

---

## 利用可能なメソッド

`BindableValidator` が提供するメソッド：

| メソッド | 説明 |
|---------|------|
| `ValidateProperty(value, name)` | 単一プロパティを検証し、`ErrorsChanged` を発火。 |
| `ValidateAllProperties()` | すべてのプロパティを一度に検証。 |
| `ClearErrors(name)` | 特定プロパティのエラーをクリア。 |
| `ClearAllErrors()` | すべての検証エラーをクリア。 |
| `GetErrors(name)` | 現在のエラーを返す（`IEnumerable`）。 |
| `HasErrors` | いずれかのプロパティにエラーがある場合 `true`。 |

---

## DataAnnotations の転送

**partial プロパティ**宣言上の `[Required]`・`[EmailAddress]`・`[MinLength]` など `ValidationAttribute` 派生属性は、ユーザーの宣言にのみ残ります——ジェネレータは実装 partial に重複して付与しないため **CS0579** を回避しつつ、`Validator` メタデータは正しく保たれます。

**フィールド**ターゲットの場合、ターゲット指定なしの DataAnnotations 属性は生成プロパティに転送されるため、バリデータが読み取れます。

---

## 診断

| ID | 深刻度 | 条件 |
|----|--------|------|
| **PSG5001** | Warning | `[NotifyDataErrorInfo]` を使用しているが、型が `BindableValidator` を継承せず `[BindableValidator]` も付与していない — 検証呼び出しは生成されません。 |

---

## 関連

- [ObservableProperty](/ja/generators/observable-property)
- [通知と転送](/ja/generators/notifications)
- [診断リファレンス](/ja/diagnostics/reference)
