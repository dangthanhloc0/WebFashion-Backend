using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BACKENDEMO.Entity
{
    public class AppUser : IdentityUser
    {
        public List<UserStock> userStocks {get; set;} = new List<UserStock>();
    }
}