using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Entity;

namespace BACKENDEMO.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}