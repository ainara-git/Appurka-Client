using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Appurka.Services.Interfaces
{
    public interface IAuthenticationStore
    {
        Account Load(string serviceId);
    }
}
