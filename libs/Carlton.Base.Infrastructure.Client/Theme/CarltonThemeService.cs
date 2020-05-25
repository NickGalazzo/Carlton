using System;

namespace Carlton.Base.Client.Theme
{
    public class CarltonThemeService
    {
        public string Theme { get; private set; }

        public event Action<string> OnThemeChange;

        public void UpdateTheme(string theme)
        {
            Theme = theme;
            OnThemeChange?.Invoke(theme);
        }
    }
}
