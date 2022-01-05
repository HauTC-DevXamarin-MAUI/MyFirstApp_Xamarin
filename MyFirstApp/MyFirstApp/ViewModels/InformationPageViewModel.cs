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
        #endregion


        private readonly INavigationService _navigationService;

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand =>
            _backCommand ?? (_backCommand = new DelegateCommand(HandleBackCommand));

        async void HandleBackCommand()
        {

            var p = new NavigationParameters();
            p.Add("name", Name);
            p.Add("email", Email);
            p.Add("uri", UriImage);

            await _navigationService.NavigateAsync("/MainPage/NavigationPage/MyPage", p);

        }
        //Const 
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

        public InformationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
