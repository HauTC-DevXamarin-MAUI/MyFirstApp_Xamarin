using MyFirstApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {

        private Post _post;
        public Post Post
        {
            get { return _post; }
            set { SetProperty(ref _post, value); }
        }
        public DetailPageViewModel()
        {

        }

        //public Task InitializeAsync(INavigationParameters parameters)
        //{
           
        //}

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("post"))
            {
                Post = parameters.GetValue<Post>("post");
            }
        }
    }
}
