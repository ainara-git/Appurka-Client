using System.Collections.Generic;
using System.Linq;
using Appurka.Services.Interfaces;
using Appurka.WinPhone.Services;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationStore))]
namespace Appurka.WinPhone.Services
{
    public class AuthenticationStore : IAuthenticationStore
    {
        public Account Load(string serviceId)
        {
            IEnumerable<Account> accounts = AccountStore.Create().FindAccountsForService(serviceId);

            return accounts.FirstOrDefault();
        }
    }
}
