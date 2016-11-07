using System.Threading.Tasks;
using System.Windows.Input;
using Appurka.Models;
using Appurka.Services.Interfaces;
using MvvmCross.Core.ViewModels;

namespace Appurka.ViewModels
{
    public class LoginPageViewModel : MvxViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginPageViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public async Task<ICommand> DoLogin()
        {
            var login = await _authenticationService.LoginAsync(Email, Password);
            if (login)
            {
                return new MvxCommand(() => ShowViewModel<LoginSuccessViewModel>());
            }
            return null;
        }

        public ICommand DoLoginFacebook()
        {
            LoginOAuthPageViewModel.AuthInformation = AuthInformation.Facebook;
            return new MvxCommand(() => ShowViewModel<LoginOAuthPageViewModel>());
        }
    }
}
