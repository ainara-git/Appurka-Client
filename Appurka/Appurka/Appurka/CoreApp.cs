using Appurka.Models;
using Appurka.Services.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Auth;

namespace Appurka
{
    public class CoreApp : MvxApplication
    {
        public Account Account { get; set; }

        public bool IsLoggedIn => Account != null;

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("ViewModel")
                .AsTypes()
                .RegisterAsDynamic();

            RegisterAppStart<ViewModels.MainViewModel>();

            LoadAccount();
        }

        private void LoadAccount()
        {
            var authenticationStore = Mvx.Resolve<IAuthenticationStore>();
            Account = authenticationStore.Load(AuthInformation.FACEBOOK);
        }
    }
}
