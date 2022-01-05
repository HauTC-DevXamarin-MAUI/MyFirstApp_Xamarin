using MyFirstApp.Models;
using MyFirstApp.Services;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFirstApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private ILoginGoogleService _loginGoogleService;
        #region loginGoole
        public UserProfile User { get; set; } = new UserProfile();
        public string Name
        {
            get => User.Name;
            set => User.Name = value;
        }

        public string Email
        {
            get => User.Email;
            set => User.Email = value;
        }

        public Uri Picture
        {
            get => User.Picture;
            set => User.Picture = value;
        }
        public string Token { get; set; }

        private DelegateCommand _loginGoogleCommand;
        public DelegateCommand LoginGoogleCommand =>
            _loginGoogleCommand ?? (_loginGoogleCommand = new DelegateCommand(LoginAsync));

        private readonly IGoogleClientManager _googleClientManager = CrossGoogleClient.Current;
        #endregion

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

        public LoginPageViewModel(INavigationService navigationService, ILoginGoogleService loginGoogleService)
        {
            _navigationService = navigationService;
            _loginGoogleService = loginGoogleService;
        }
        #region LoginGoole
        public async void LoginAsync()
        {
            _googleClientManager.OnLogin += OnLoginCompleted;
            await _loginGoogleService.LoginAsync();           
        }
        const string NameEmail = "name";
        const string EmailAddress = "email";
        const string UriPicture = "uri";
        private async void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data != null)
            {
                GoogleUser googleUser = loginEventArgs.Data;
                User.Name = googleUser.Name;
                User.Email = googleUser.Email;
                User.Picture = googleUser.Picture;
                var GivenName = googleUser.GivenName;
                var FamilyName = googleUser.FamilyName;
                var token = CrossGoogleClient.Current.AccessToken;
                Token = token;

                var p = new NavigationParameters();
                p.Add(NameEmail, User.Name);
                p.Add(EmailAddress, User.Email);
                p.Add(UriPicture, User.Picture.AbsoluteUri.ToString());

                await _navigationService.NavigateAsync("/MainPage/NavigationPage/MyPage", p);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
            }

            _googleClientManager.OnLogin -= OnLoginCompleted;

        }

        #endregion



        private readonly INavigationService _navigationService;

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(HandleLoginCommand, HandleCanLoginCommand));

        
        async void HandleLoginCommand()
        {
            var p = new NavigationParameters();
            p.Add(NameEmail, UserName);
            p.Add(EmailAddress, PassWord);
            p.Add(UriPicture, "hau.jpg");

            await _navigationService.NavigateAsync("/MainPage/NavigationPage/MyPage",p);
        }

        bool HandleCanLoginCommand()
        {
            return true;
        }


       
    }
}
