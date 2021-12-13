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


        //protected IEventAggregator _ea;      
        //void HandleSubscribe()
        //{
        //    _ea.GetEvent<SendEvent>().Subscribe(MessageReceived, ThreadOption.UIThread);
        //}
        //private void MessageReceived(string obj)
        //{
        //    ABC = obj;
        //}


        private readonly INavigationService _navigationService;

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand =>
            _backCommand ?? (_backCommand = new DelegateCommand(ExecuteBackCommand));

        async void ExecuteBackCommand()
        {
            var p = new NavigationParameters();
            p.Add("name", UserName);
            p.Add("pass", PassWord);
            await _navigationService.NavigateAsync("/MainPage/NavigationPage/MyPage", p);
            //await _navigationService.NavigateAsync("/NavigationPage/MainPage/MyPage");

        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            UserName = parameters.GetValue<String>("name");
            PassWord = parameters.GetValue<String>("pass");
        }

        public InformationPageViewModel(INavigationService navigationService)
        {
            //_ea = ea;
            //HandleSubscribe();
            _navigationService = navigationService;
        }
    }
}
