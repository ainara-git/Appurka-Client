using Appurka.Droid.Services;
using Appurka.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationStore))]
namespace Appurka.Droid.Services
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
