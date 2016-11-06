using System;
using Appurka.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Appurka.ViewModels
{
    public class LoginOAuthPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        public DelegateCommand SuccessfulLoginCommand { get; set; }

        public DelegateCommand CancelLoginCommand { get; set; }

        public static AuthInformation AuthInformation { get; set; }

        public LoginOAuthPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SuccessfulLoginCommand = new DelegateCommand(SuccessfulLogin);
            CancelLoginCommand = new DelegateCommand(CancelLogin);
        }

        private void CancelLogin()
        {
            _navigationService.GoBackAsync(new NavigationParameters("logged=false"));
        }

        void SuccessfulLogin()
        {
            _navigationService.GoBackAsync(new NavigationParameters("logged=true"));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
