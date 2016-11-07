using Windows.UI.Xaml.Controls;
using Appurka.Services.Interfaces;
using Appurka.Windows.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Forms.Presenter.Windows81;
using MvvmCross.Platform;
using MvvmCross.WindowsCommon.Platform;
using MvvmCross.WindowsCommon.Views;

namespace Appurka.Windows
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
            var presenter = new MvxFormsWindows81PagePresenter(rootFrame, xamarinFormsApp);
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
