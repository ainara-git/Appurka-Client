using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.Forms.Presenter.iOS;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using UIKit;
using Xamarin.Forms;

namespace Appurka.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new CoreApp();
        }
        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();
            var xamarinFormsApp = new MvxFormsApp();
            return new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
        }
    }
}