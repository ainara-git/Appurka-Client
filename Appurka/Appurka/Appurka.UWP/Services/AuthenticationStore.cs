﻿using System.Linq;
using Appurka.Services.Interfaces;
using Xamarin.Auth;

namespace Appurka.UWP.Services
{
    public class AuthenticationStore : IAuthenticationStore
    {
        public Account Load(string serviceId)
        {
            var accounts = AccountStore.Create().FindAccountsForService(serviceId);
            return accounts.FirstOrDefault();
        }
    }
}
