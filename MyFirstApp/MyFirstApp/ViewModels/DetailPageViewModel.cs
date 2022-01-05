using MyFirstApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {

        private Post _post;
        
        public Post Post
        {
            get { return _post; }
            set { SetProperty(ref _post, value); }
        }
        public DetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
           
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("post"))
            {
                Post = parameters.GetValue<Post>("post");
            }
        }
    }
}
