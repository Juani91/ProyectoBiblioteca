using Contract.UserContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface ICustomAuthenticationService
    {
        string Autenticar(AuthenticationRequest authenticationRequest);
    }
}
