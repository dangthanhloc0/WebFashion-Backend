
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;
using Libs.Data;
using Libs.Entity;
using Libs.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Libs.Service
{
 
    public class TokenService 
    {
        private IToken _iToken;
        public TokenService(IToken token)
        {
            _iToken = token;
        }

        public string CreateToken(AppUser user)
        {
            return _iToken.CreateToken(user);
        }


    }
}