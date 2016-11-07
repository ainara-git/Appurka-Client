using Appurka.Services.Interfaces;
using Appurka.UWP.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Forms.Presenter.WindowsUWP;
using MvvmCross.Platform;
using MvvmCross.WindowsUWP.Platform;
using MvvmCross.WindowsUWP.Views;
using Frame = Windows.UI.Xaml.Controls.Frame;

namespace Appurka.UWP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame, string suspensionManagerSessionStateKey = null) : base(rootFrame, suspensionManagerSessionStateKey)
        {
        }

        public Setup(IMvxWindowsFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new CoreApp();
        }

        protected override IMvxWindowsViewPresenter CreateViewPresenter(IMvxWindowsFrame rootFrame)
        {
            var xamarinFormsApp = new MvxFormsApp();
            var presenter = new MvxFormsWindowsUWPPagePresenter(rootFrame, xamarinFormsApp);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterSingleton<IAuthenticationStore>(new AuthenticationStore());
            base.InitializeFirstChance();
        }
    }
}
