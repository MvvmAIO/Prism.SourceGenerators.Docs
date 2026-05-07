using MudBlazor;

namespace Prism.SourceGenerators.Docs.Theme;

/// <summary>
/// Central theme for the documentation site (brand-aligned palette, layout defaults).
/// </summary>
internal static class DocsMudTheme
{
    internal static MudTheme Default { get; } = Create();

    private static MudTheme Create()
    {
        var theme = new MudTheme
        {
            PaletteLight = new PaletteLight
            {
                Primary = "#1b6ec2",
                Secondary = "#3a0647",
                Tertiary = "#052767",
                AppbarBackground = "#f7f7f7",
                AppbarText = "#424242",
                DrawerBackground = "#0d1b4a",
                DrawerText = "rgba(255,255,255,0.92)",
                DrawerIcon = "rgba(255,255,255,0.92)",
                Background = "#fafafa",
                Surface = "#ffffff",
            },
            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "8px",
            },
        };

        return theme;
    }
}
