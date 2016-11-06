using Xamarin.Forms;

namespace Appurka.Views
{
    public partial class LoginOAuthPage : ContentPage
    {
        public LoginOAuthPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.Instance.IsLoggedIn)
            {
                Navigation.PopModalAsync();
            }
        }
    }
}
