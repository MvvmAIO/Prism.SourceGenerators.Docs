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
                Primary = "#2563eb",
                Secondary = "#7c3aed",
                Tertiary = "#0f766e",
                Info = "#0284c7",
                Success = "#059669",
                Warning = "#d97706",
                Error = "#dc2626",
                AppbarBackground = "rgba(255,255,255,0.86)",
                AppbarText = "#111827",
                DrawerBackground = "#0d1b4a",
                DrawerText = "rgba(255,255,255,0.92)",
                DrawerIcon = "rgba(255,255,255,0.92)",
                Background = "#f6f8fc",
                BackgroundGray = "#eef2ff",
                Surface = "#ffffff",
                TextPrimary = "#111827",
                TextSecondary = "#4b5563",
                LinesDefault = "rgba(15,23,42,0.12)",
                Divider = "rgba(15,23,42,0.12)",
            },
            PaletteDark = new PaletteDark
            {
                Primary = "#7dd3fc",
                Secondary = "#c4b5fd",
                Tertiary = "#5eead4",
                Info = "#38bdf8",
                Success = "#34d399",
                Warning = "#fbbf24",
                Error = "#f87171",
                AppbarBackground = "rgba(15,23,42,0.86)",
                AppbarText = "#f8fafc",
                DrawerBackground = "#07111f",
                DrawerText = "rgba(248,250,252,0.92)",
                DrawerIcon = "rgba(248,250,252,0.92)",
                Background = "#080f1f",
                BackgroundGray = "#111827",
                Surface = "#111827",
                TextPrimary = "#f8fafc",
                TextSecondary = "#cbd5e1",
                LinesDefault = "rgba(148,163,184,0.22)",
                Divider = "rgba(148,163,184,0.22)",
            },
            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "14px",
                DrawerMiniWidthLeft = "72px",
                DrawerWidthLeft = "280px",
                AppbarHeight = "64px",
            },
        };

        return theme;
    }
}
