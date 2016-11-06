using System.Threading.Tasks;
using Appurka.Services.Interfaces;

namespace Appurka.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> LoginAsync(string email, string password)
        {
            await Task.Delay(1000);
            return true;
        }
    }
}
