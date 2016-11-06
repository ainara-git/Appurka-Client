using Appurka.Services.Interfaces;
using Appurka.WinPhone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationStore))]
namespace Appurka.WinPhone.Services
{
    public class AuthenticationStore : IAuthenticationStore
    {
        public Account Load(string serviceId)
        {
            try
            {
                //TODO: This code does not work
                IEnumerable<Account> accounts = AccountStore.Create().FindAccountsForService(serviceId);

                return accounts.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
