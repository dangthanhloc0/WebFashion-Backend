using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Dtos.User
{
    public class newUserDto
    {
        public string ? Username {get; set;}      
        public string ? EmailAddress {get; set;} 

        public string ? Token {get; set;} 
    }
}