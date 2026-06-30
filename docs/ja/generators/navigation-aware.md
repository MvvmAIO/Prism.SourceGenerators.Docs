---
title: NavigationAware
description: Prism INavigationAware メンバーを生成。
---

# NavigationAware

**partial** クラスに **`[NavigationAware]`** を付与すると **`INavigationAware`** メンバーが生成されます。詳細は [英語版](/generators/navigation-aware) を参照。

## `[FromNavigationParameter]`

**`[FromNavigationParameter]`** を `[ObservableProperty]` フィールドまたは partial property に付与すると、`OnNavigatedToCore` が呼び出される前に `TryGetValue<T>` で `NavigationContext.Parameters` から型付き値を読み取り、プロパティ setter を通じて代入します。

```csharp
[NavigationAware]
public partial class DashboardViewModel : BindableBase
{
    [FromNavigationParameter("userId")]
    [ObservableProperty]
    public partial int UserId { get; set; }

    [FromNavigationParameter]  // key は既定で "UserName"
    [ObservableProperty]
    public partial string UserName { get; set; }
}
```

パラメータが存在しない場合、プロパティは初期値を保持します。key を省略した場合はプロパティ名が既定値になります。

診断: **PSG0007**（クラスが `partial` でない）、**PSG7006**（属性がフィールド/プロパティ以外のメンバに適用された）、**PSG7007**（メンバに `[ObservableProperty]` がない）、**PSG7008**（key が空）。
