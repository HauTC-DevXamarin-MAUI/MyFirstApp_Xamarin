using MyFirstApp.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MyFirstApp.ViewModels
{
    public class SettingsPageViewModel : BindableBase
    {
        public bool IsToggled { get; set; }
        public DelegateCommand InitToggledCommand { get; set; }
        public SettingsPageViewModel()
        {
            InitToggledCommand = new DelegateCommand(() => ExcuteItemSelected());
        }

        private void ExcuteItemSelected()
        {
            IsToggled = !IsToggled;
            if(IsToggled)
            {
                App.Current.UserAppTheme = OSAppTheme.Light;
            }
            else
                App.Current.UserAppTheme = OSAppTheme.Dark;

        }
    }
}
