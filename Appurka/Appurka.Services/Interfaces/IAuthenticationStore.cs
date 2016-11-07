using Xamarin.Auth;

namespace Appurka.Services.Interfaces
{
    public interface IAuthenticationStore
    {
        Account Load(string serviceId);
    }
}
