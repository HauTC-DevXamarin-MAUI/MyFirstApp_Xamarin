using MyFirstApp.Services;
using MyFirstApp.ViewModels;
using MyFirstApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MyFirstApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();


            await NavigationService.NavigateAsync("LoginPage");
            //await NavigationService.NavigateAsync("/MainPage/NavigationPage/InformationPage");
            //await NavigationService.NavigateAsync("/MainPage/NavigationPage/SettingsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<InformationPage, InformationPageViewModel>();
            containerRegistry.RegisterForNavigation<ListPage, ListPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MyPage, MyPageViewModel>();

            containerRegistry.Register<IPhotoService, PhotoService>();
            containerRegistry.Register<IAlbumService, AlbumService>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<ILoginGoogleService, LoginGoogleService>();


            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
        }
    }
}
