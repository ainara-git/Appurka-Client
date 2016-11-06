using Appurka.Models;
using Appurka.Services.Interfaces;
using Xamarin.Auth;
using Xamarin.Forms;

namespace Appurka
{
    public partial class App : Application
    {
        public Account Account { get; set; }

        public bool IsLoggedIn => Account != null;

        public App()
        {
            InitializeComponent();
            LoadAccount();
            MainPage = new Views.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void LoadAccount()
        {
          //  var authenticationStore = DependencyService.Get<IAuthenticationStore>();
          //  Account = authenticationStore.Load(AuthInformation.FACEBOOK);
        }
    }
}
