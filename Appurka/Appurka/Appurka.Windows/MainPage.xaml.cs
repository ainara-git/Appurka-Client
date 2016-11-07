using System;
using Windows.UI.Xaml;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Presenter.Windows81;
using MvvmCross.Platform;
using Xamarin.Forms.Platform.WinRT;

namespace Appurka.Windows
{
    public sealed partial class MainPage : WindowsPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Start MvvMCross
            var start = Mvx.Resolve<MvvmCross.Core.ViewModels.IMvxAppStart>();
            start.Start();

            // Locate the MvvMCross-Forms Presenter
            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsWindows81PagePresenter;


            // Xamarin.Forms.Platform.WinRT.dll Loads the Xamarin Form found at presenter.MvxFormsApp
            LoadApplication(presenter.MvxFormsApp);

            LayoutUpdated += MainPage_LayoutUpdated;
        }

        private void MainPage_LayoutUpdated(object sender, object e)
        {
            try
            {
                if (BottomAppBar != null)
                {
                    this.BottomAppBar.IsOpen = true;
                    this.BottomAppBar.Visibility = Visibility.Visible;
                    this.BottomAppBar.IsSticky = true;
                }
            }
            catch (Exception ex) { }
        }
    }
}
