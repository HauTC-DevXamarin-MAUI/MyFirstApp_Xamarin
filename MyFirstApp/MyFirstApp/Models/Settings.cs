using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MyFirstApp.Models
{
    public static class Settings
    {
        // 0 light, 1 dark
        const int theme = 0;
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }
    }
}
