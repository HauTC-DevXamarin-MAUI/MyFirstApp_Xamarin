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
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        private string _passWord;
        public string PassWord
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
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
            p.Add("name", UserName);
            p.Add("pass", PassWord);
            _navigationService.NavigateAsync("MainPage/NavigationPage/InformationPage",p);

        }
        const string UserNameKey = "name";
        const string PassWordKey = "pass";

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(UserNameKey))
            {
                UserName = parameters.GetValue<String>(UserNameKey);
            }
            if (parameters.ContainsKey(PassWordKey))
            {
                PassWord = parameters.GetValue<String>(PassWordKey);
            }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            //Duration = 150;
            _navigationService = navigationService;
        }


        //Logout Command
        private DelegateCommand<string> _longPressCommandButtonLogOut;
        public DelegateCommand<string> LongPressCommandButtonLogOut =>
            _longPressCommandButtonLogOut ?? (_longPressCommandButtonLogOut = new DelegateCommand<string>(ExecuteLongPressCommand));

        void ExecuteLongPressCommand(string uri)
        {
            _navigationService.NavigateAsync(uri);
        }

    }
}
