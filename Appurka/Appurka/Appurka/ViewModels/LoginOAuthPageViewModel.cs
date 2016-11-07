using Appurka.Models;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;

namespace Appurka.ViewModels
{
    public class LoginOAuthPageViewModel : MvxViewModel
    {
        public static AuthInformation AuthInformation { get; set; }
        public Command SuccessfulLoginCommand { get; set; }

        public Command CancelLoginCommand { get; set; }

        public LoginOAuthPageViewModel()
        {
            SuccessfulLoginCommand = new Command(SuccessfulLogin);
            CancelLoginCommand = new Command(CancelLogin);
        }

        private void CancelLogin()
        {
            DisplayAlert("Error", "Cannot login with the given username and password.");
        }

        void SuccessfulLogin()
        {
            DisplayAlert("Error", "Cannot login with the given username and password.");
        }

        public void DisplayAlert(string title, string message)
        {
            string[] values = { title, message };
            MessagingCenter.Send<LoginOAuthPageViewModel, string[]>(this, "DisplayAlert", values);
        }
    }
}
