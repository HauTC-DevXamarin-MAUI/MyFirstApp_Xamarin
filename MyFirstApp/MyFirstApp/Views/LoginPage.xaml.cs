using Xamarin.Forms;

namespace MyFirstApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //showLoginIndicator.IsRunning = false;
        }

        private void Button_OnClicked(object sender, System.EventArgs e)
        {
            //showLoginIndicator.IsVisible = true;
            //showLoginIndicator.IsRunning = true;
        }
    }
}
