using Microsoft.UI.Xaml;

namespace SwitchingThemesSampleApp
{
    public interface IThemeSelectorService
    {
        ElementTheme GetTheme();
        void SetTheme(ElementTheme theme);
    }
}
