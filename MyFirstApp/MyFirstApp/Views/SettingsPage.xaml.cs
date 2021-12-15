using MyFirstApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFirstApp.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            switch (Settings.Theme)
            {
                case 0:
                    switchTheme.IsToggled = false;
                    break;
                case 1:
                    switchTheme.IsToggled = true;
                    break;
            }

        }
        
    }
}
