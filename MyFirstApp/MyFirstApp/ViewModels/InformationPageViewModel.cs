using MyFirstApp.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.ViewModels
{
    public class InformationPageViewModel : BindableBase, IInitializeAsync
    {
        //Parameters Username and PassWord
        #region Parameters Username and PassWord
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _passWord;
        public string PassWord
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
        }
        #endregion


        private readonly INavigationService _navigationService;

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand =>
            _backCommand ?? (_backCommand = new DelegateCommand(HandleBackCommand));

        async void HandleBackCommand()
        {

            var p = new NavigationParameters();
            p.Add("name", UserName);
            p.Add("pass", PassWord);

            await _navigationService.NavigateAsync("/MainPage/NavigationPage/MyPage", p);

        }
        //Const 
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

        public InformationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
