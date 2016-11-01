using Appurka.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace Appurka.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        public async Task<bool> LoginAsync(string email, string password)
        {
            await Task.Run(() => {  });
            return true;
        }
    }
}
