using Appurka.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appurka.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        #region Members

        private INavigationService _navigationService;
        private IAuthenticateService _authenticateService;

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


        #endregion Commands

        public LoginPageViewModel(INavigationService navigationService, IAuthenticateService authenticateService)
        {
            _navigationService = navigationService;
            _authenticateService = authenticateService;
            LoginCommand = new DelegateCommand(Login);
        }

        async void Login()
        {
            bool login = await _authenticateService.LoginAsync(Email, Password);
            if(login)
            {
                await _navigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
            }
        }
    }
}
