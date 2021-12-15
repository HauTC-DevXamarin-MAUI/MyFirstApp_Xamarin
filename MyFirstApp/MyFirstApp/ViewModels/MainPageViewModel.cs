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
        const string User_Name = "name";
        const string Pass_Word = "pass";

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(User_Name))
            {
                UserName = parameters.GetValue<String>(User_Name);
            }
            if (parameters.ContainsKey(Pass_Word))
            {
                PassWord = parameters.GetValue<String>(Pass_Word);
            }
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


        private DelegateCommand _abc;
        public DelegateCommand HauCommand =>
            _abc ?? (_abc = new DelegateCommand(ExecuteHauCommand));

        void ExecuteHauCommand()
        {
            _navigationService.NavigateAsync("LoginPage");
        }
        

    }
}
