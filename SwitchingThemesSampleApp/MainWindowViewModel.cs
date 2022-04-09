using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Windows.Input;

namespace SwitchingThemesSampleApp
{
    public class MainWindowViewModel : ObservableObject
    {
        private string? _topTitle;
        private SolidColorBrush? _themeColor;
        private string? _textBoxText;
        private readonly IThemeSelectorService _themeSelectorService;

        public string? TopTitle
        {
            get => _topTitle;
            set => SetProperty(ref _topTitle, value);
        }

        public SolidColorBrush? ThemeColor
        {
            get => _themeColor;
            set => SetProperty(ref _themeColor, value);
        }

        public string? TextBoxText
        {
            get => _textBoxText;
            set => SetProperty(ref _textBoxText, value);
        }

        public ICommand SetThemeCommand { get; }


        public MainWindowViewModel(IThemeSelectorService themeSelectorService)
        {
            SetThemeCommand = new RelayCommand<string>((themeName) => UpdateTheme(themeName));
            _themeSelectorService = themeSelectorService;
            UpdateTheme("Default");
        }

        private void UpdateTheme(string? themeName)
        {
            if (Enum.TryParse(themeName, out ElementTheme theme) is true)
            {
                _themeSelectorService.SetTheme(theme);
                TopTitle = theme switch
                {
                    ElementTheme.Light => "GOOD SIDE",
                    ElementTheme.Dark => "DARK SIDE",
                    _ => "NEUTRAL SIDE",
                };
                ThemeColor = theme switch
                {
                    ElementTheme.Light => new SolidColorBrush(Colors.LightGreen),
                    ElementTheme.Dark => new SolidColorBrush(Colors.Red),
                    _ => new SolidColorBrush(Colors.Gray),
                };
                TextBoxText = theme switch
                {
                    ElementTheme.Light => "May the Force be with you.",
                    ElementTheme.Dark => "May the Force serve you well.",
                    _ => "?",
                };
            }
        }
    }
}
