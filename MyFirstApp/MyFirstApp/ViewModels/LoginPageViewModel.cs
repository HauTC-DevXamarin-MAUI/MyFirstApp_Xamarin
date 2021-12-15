using MyFirstApp.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MyFirstApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
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
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }


        //#region EventAggregator

        //protected IEventAggregator _ea;

        //void HandleSend()
        //{
        //    _ea.GetEvent<SendEvent>().Publish(UserName);
        //    //_ea.GetEvent<SendEvent>().Publish(PassWord);
        //}

        //#endregion

        public LoginPageViewModel()
        {
            //IsEnable = true;
        }
        //protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        //{
        //    base.OnPropertyChanged(args);
        //    if (args.PropertyName == "IsEnable" && IsEnable == false)
        //    {

        //    }
        //}

        private readonly INavigationService _navigationService;

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(HandleLoginCommand, HandleCanLoginCommand));

        async void HandleLoginCommand()
        {
            var p = new NavigationParameters();
            p.Add("name", UserName);
            p.Add("pass", PassWord);

            await _navigationService.NavigateAsync("/MainPage/NavigationPage/MyPage",p);
        }

        bool HandleCanLoginCommand()
        {
            return !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(PassWord) && IsChecked;
        }


        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
