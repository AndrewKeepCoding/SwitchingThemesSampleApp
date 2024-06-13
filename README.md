# SwitchingThemesSampleApp
This is the source code from my YouTube video about switching themes on WinUI 3 app.

YouTube: https://youtu.be/w2XdbyNrXBQ

# Update

If you want to use a `ComboBox`:

```xaml
<ComboBox
    SelectedIndex="0"
    SelectionChanged="ComboBox_SelectionChanged">
    <x:String>Default</x:String>
    <x:String>Light</x:String>
    <x:String>Dark</x:String>
</ComboBox>
```

and in code-behind, get the `IThemeSelectorService`:

```cs
private readonly IThemeSelectorService _themeSelectorService = Ioc.Default.GetRequiredService<IThemeSelectorService>();
```

and handle the `SelectionChanged` event:

```cs
private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (e.AddedItems.FirstOrDefault() is not string themeName ||
        Enum.TryParse<ElementTheme>(themeName, out var theme) is not true)
    {
        return;
    }

    _themeSelectorService.SetTheme(theme);
}
```
