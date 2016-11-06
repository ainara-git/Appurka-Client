using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appurka.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string email, string password);
    }
}
