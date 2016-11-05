using Appurka.Models;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms;

namespace Appurka.ViewModels
{
    public class LoginOAuthPageViewModel : BindableBase
    {
        public DelegateCommand SuccessfulLoginCommand { get; set; }

        public static AuthInformation AuthInformation { get; set; }

        public LoginOAuthPageViewModel()
        {
            SuccessfulLoginCommand = new DelegateCommand(Navigate);
        }

        void Navigate()
        {
            ((ContentPage)Application.Current.MainPage).Navigation.PopModalAsync();
        }
    }
}
