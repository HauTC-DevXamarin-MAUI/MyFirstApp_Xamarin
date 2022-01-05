using MyFirstApp.Services;
using Plugin.GoogleClient;
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
        private ILoginGoogleService _loginGoogleService;
        #region LogoutGoogle
        private readonly IGoogleClientManager _googleClientManager = CrossGoogleClient.Current;
        private DelegateCommand _logoutGoogleCommand;
        public DelegateCommand LogoutGoogleCommand =>
            _logoutGoogleCommand ?? (_logoutGoogleCommand = new DelegateCommand(Logout));

        public void Logout()
        {
            _googleClientManager.OnLogout += OnLogoutCompleted;
            _loginGoogleService.Logout();
        }

        private void OnLogoutCompleted(object sender, EventArgs loginEventArgs)
        {
            _googleClientManager.OnLogout -= OnLogoutCompleted;
            _navigationService.NavigateAsync("/LoginPage");
        }
        #endregion

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        private string _uriImage;
        public string UriImage
        {
            get { return _uriImage; }
            set { SetProperty(ref _uriImage, value); }
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
            p.Add(NameEmail, Name);
            p.Add(EmailAddress, Email);
            p.Add(UriPicture, UriImage);
            _navigationService.NavigateAsync("MainPage/NavigationPage/InformationPage",p);

        }
        const string NameEmail = "name";
        const string EmailAddress = "email";
        const string UriPicture = "uri";

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(NameEmail))
            {
                Name = parameters.GetValue<String>(NameEmail);
            }
            if (parameters.ContainsKey(EmailAddress))
            {
                Email = parameters.GetValue<String>(EmailAddress);
            }
            if (parameters.ContainsKey(UriPicture))
            {
                UriImage = parameters.GetValue<String>(UriPicture);
            }
        }

        public MainPageViewModel(INavigationService navigationService, ILoginGoogleService loginGoogleService)
        {
            //Duration = 150;
            _loginGoogleService = loginGoogleService;
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
