using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymenTControLL.Api.Auth
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
