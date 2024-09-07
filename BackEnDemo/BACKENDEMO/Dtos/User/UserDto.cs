using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDEMO.Dtos.User
{
    public class UserDto
    {   
        [Required]
        public string ? Username {get; set;}      

        [Required]
        [EmailAddress]
        public string ? EmailAddress {get; set;} 

        [Required]
        public string ? Password {get; set;} 
    
    }
}