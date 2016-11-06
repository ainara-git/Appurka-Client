using System;
using Appurka.Models;
using Appurka.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Appurka.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        #region Members

        private INavigationService _navigationService;
        private IAuthenticationService _authenticateService;

        #endregion Members

        #region Properties

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand LoginCommand { get; set; }

        public DelegateCommand FacebookCommand { get; set; }


        #endregion Commands

        public LoginPageViewModel(INavigationService navigationService, IAuthenticationService authenticateService)
        {
            _navigationService = navigationService;
            _authenticateService = authenticateService;
            LoginCommand = new DelegateCommand(Login);
            FacebookCommand = new DelegateCommand(Facebook);
        }

        async private void Facebook()
        {
            LoginOAuthPageViewModel.AuthInformation = AuthInformation.Facebook;

            await _navigationService.NavigateAsync("LoginOAuthPage?provider=facebook");
        }

        async private void Login()
        {
            bool login = await _authenticateService.LoginAsync(Email, Password);
            if(login)
            {
                await _navigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("logged") && parameters["logged"].Equals("true"))
            {
                _navigationService.GoBackAsync(new NavigationParameters("logged=true"));
            }
        }
    }
}
