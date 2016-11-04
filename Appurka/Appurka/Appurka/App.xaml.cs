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

namespace Appurka
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("LoginPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();

            Container.RegisterType<IAuthenticateService, AuthenticateService>();
        }
    }
}
