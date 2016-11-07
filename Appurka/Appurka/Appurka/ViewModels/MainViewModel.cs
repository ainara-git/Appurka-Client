using MvvmCross.Core.ViewModels;

namespace Appurka.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
            _appName = "Appurka";
        }

        private string _appName;
        public string AppName
        {
            get { return _appName; }
            set
            {
                _appName = value;
                RaisePropertyChanged(() => AppName);
            }
        }
    }
}
