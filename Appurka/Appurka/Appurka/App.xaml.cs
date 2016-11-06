using Appurka.Services;
using Appurka.Services.Interfaces;
using Appurka.Views;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Xamarin.Auth;
using Appurka.Models;

namespace Appurka
{
    public partial class App : PrismApplication
    {
        public static App Instance { get { return Current as App; } }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        
        public Account Account { get; set; }

        public bool IsLoggedIn
        {
            get
            {
                return Account != null;
            }
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            LoadAccount();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<LoginOAuthPage>();

            Container.RegisterType<IAuthenticationService, AuthenticationService>();
        }

        private void LoadAccount()
        {
            var authenticationStore = DependencyService.Get<IAuthenticationStore>();
            Account = authenticationStore.Load(AuthInformation.FACEBOOK);
        }
    }
}
