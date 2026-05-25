---
title: はじめに
---

# インストールと参照

**BindableBase**（または互換ベース）を使う Prism アプリにパッケージを追加します。

!!! note "言語"
    [English](../getting-started/) · [简体中文](../zh-cn/getting-started/)

## 1. パッケージ

```bash
dotnet add package MvvmAIO.Prism.SourceGenerators
```

## 2. partial 型

```csharp
public partial class MainViewModel : BindableBase
{
    [ObservableProperty]
    private string _title = "";
}
```

## 3. Prism 8 と 9

Prism.Core **8.1.97** では **MvvmAIO.Prism.Bcl.Commands** が必要な場合があります。

```bash
dotnet add package MvvmAIO.Prism.Bcl.Commands
```

## 4. サンプル

**[Prism.SourceGenerators.Samples](https://github.com/MvvmAIO/Prism.SourceGenerators.Samples)** をクローンし、**`Prism.SourceGenerators.Samples.slnx`** をビルドします。構成、Validation、ジェネレータの **ローカル参照と NuGet** の切り替えは **[サンプル](samples.md)** を参照してください。

## 要件

- **.NET 10 SDK**
- VS 2022 17.13+ / Rider / VS Code + C# Dev Kit

## 推奨 `PackageReference`

```xml
<ItemGroup>
  <PackageReference Include="MvvmAIO.Prism.SourceGenerators" Version="0.4.2" />
  <PackageReference Include="MvvmAIO.Prism.Bcl.Commands" Version="0.4.1" />
</ItemGroup>
```

## ビルド

```bash
dotnet build Prism.SourceGenerators.slnx
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

## アップグレード注意

- C# 13+ の partial-property `[ObservableProperty]`
- C# 14+ の `field` によるコマンド生成
- `ValueTask` は `.AsTask()` 経由
- 不足シンボルは **PSG3002**
