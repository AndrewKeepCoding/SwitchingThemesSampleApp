using Microsoft.UI.Xaml;

namespace SwitchingThemesSampleApp
{
    public class ThemeSelectorService : IThemeSelectorService
    {
        public ElementTheme GetTheme()
        {
            if (App.Window?.Content is FrameworkElement frameworkElement)
            {
                return frameworkElement.ActualTheme;
            }
            return ElementTheme.Default;
        }

        public void SetTheme(ElementTheme theme)
        {
            if (App.Window?.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = theme;
            }
        }
    }
}
