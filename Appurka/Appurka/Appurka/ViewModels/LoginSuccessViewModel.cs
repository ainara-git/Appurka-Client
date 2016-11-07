using MvvmCross.Core.ViewModels;

namespace Appurka.ViewModels
{
    public class LoginSuccessViewModel : MvxViewModel
    {
        public LoginSuccessViewModel()
        {
            _message = "You are logged in Appurka!!";
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }
    }
}
