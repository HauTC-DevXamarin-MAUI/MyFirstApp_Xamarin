using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstApp.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogOut_Pressed(object sender, EventArgs e)
        {
            SetButtonLongClick(btnLogOut, 1500, () =>
            {
                Console.WriteLine("OK roi do");
            });
        }

        public static void SetButtonLongClick(Button _btn, int ms, Action _act)
        {
            var pressing = false;
            _btn.Pressed += (object sender, EventArgs e) =>
            {
                pressing = true;
                Task.Run(async () =>
                {
                    await Task.Delay(ms);
                    if (pressing == true)
                    {
                        pressing = false;
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            _act.Invoke();
                        });
                    }
                });
            };
            _btn.Clicked += (object sender, EventArgs e) =>
            {
                pressing = false;
            };
        }

        //private void btnLogOut_OnClicked(object sender, EventArgs e)
        //{
        //    SetButtonLongClick(btnLogOut, 1500, () => {
        //        Navigation.PushAsync(new LoginPage());
        //    });
        //}
    }
}