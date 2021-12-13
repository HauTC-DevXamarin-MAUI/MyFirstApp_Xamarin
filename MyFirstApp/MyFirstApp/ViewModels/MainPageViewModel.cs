using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.ViewModels
{
    public class MainPageViewModel : BindableBase, IInitializeAsync
    {
        //private int duration;
        //public int Duration
        //{
        //    get { return duration; }
        //    set { SetProperty(ref duration, value); }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _pass;
        public string Pass
        {
            get { return _pass; }
            set { SetProperty(ref _pass, value); }
        }

        //Navigation URI
        private readonly INavigationService _navigationService;

        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand, CanExecuteNavigateCommand));

        void ExecuteNavigateCommand(string uri)
        {
            _navigationService.NavigateAsync(uri);

        }
        bool CanExecuteNavigateCommand(string uri)
        {
            return true;
        }

        //NavigateParameterCommand
        private DelegateCommand _navigateParameterCommand;
        public DelegateCommand NavigateParameterCommand =>
            _navigateParameterCommand ?? (_navigateParameterCommand = new DelegateCommand(ExecuteNavigateParameterCommand));

        void ExecuteNavigateParameterCommand()
        {
            var p = new NavigationParameters();
            p.Add("name", Name);
            p.Add("pass", Pass);
            _navigationService.NavigateAsync("MainPage/NavigationPage/InformationPage",p);

        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            Name = parameters.GetValue<String>("name");
            Pass = parameters.GetValue<String>("pass");
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            //Duration = 150;
            _navigationService = navigationService;
        }


        //Logout Command
        private DelegateCommand<string> _longPressCommand;
        public DelegateCommand<string> LongPressCommand =>
            _longPressCommand ?? (_longPressCommand = new DelegateCommand<string>(ExecuteLongPressCommand));

        void ExecuteLongPressCommand(string uri)
        {
            _navigationService.NavigateAsync(uri);
        }

    }
}
