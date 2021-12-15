using MyFirstApp.Models;
using MyFirstApp.Services;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstApp.ViewModels
{
    public class ListPageViewModel : BindableBase

    {
        INavigationService _navigationService;
        IPhotoService _photoService;
        IUserService _userService;
        IAlbumService _albumService;

        private Post _post;
        public Post Post
        {
            get { return _post; }
            set { SetProperty(ref _post, value); }
        }
        List<Photo> PhotoList { get; set; } = new List<Photo>();
        List<User> UserList { get; set; } = new List<User>();
        List<Album> AlbumList { get; set; } = new List<Album>();
        public ObservableCollection<Post> PostList { get; set; } = new ObservableCollection<Post>();

        public DelegateCommand<Post> OnItemSelectedCommand{ get; set; }
        public ListPageViewModel(IPhotoService photoService, IAlbumService albumService, IUserService userService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _albumService = albumService;
            _userService = userService;
            _photoService = photoService;
            OnItemSelectedCommand = new DelegateCommand<Post>(ExcuteItemSelected);
            CallApi();
        }

        private async void ExcuteItemSelected(Post obj)
        {
            if (obj != null)
            {
                var p = new NavigationParameters();
                p.Add("post", obj);

                await _navigationService.NavigateAsync("DetailPage", p);
            }
        }


        private async void CallApi()
        {
            var users = await _userService.GetUsers();
            //UserList.AddRange(users);
            UserList = users;

            var photos = await _photoService.GetPhotos();
            PhotoList = photos;

            var albums = await _albumService.GetAlbums();
            AlbumList = albums;

            var listPost = from p in PhotoList
                           join a in AlbumList on p.AlbumId.ToString() equals a.Id.ToString()
                           join u in UserList on a.UserId.ToString() equals u.Id.ToString()
                           select new
                           {
                               p.Title,
                               p.ThumbnailUrl,
                               a.TitleAlbum,
                               u.UserName
                           };
            if (listPost == null) return;
            foreach (var item in listPost)
            {
                PostList.Add(new Post(item.Title, item.ThumbnailUrl, item.TitleAlbum, item.UserName));
            }
        }
    }
}
