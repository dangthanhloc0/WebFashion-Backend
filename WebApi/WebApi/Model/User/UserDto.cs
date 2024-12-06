using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model.User
{
    public class UserDto
    {   
        public string ? Username {get; set;}      

        [Required]
        [EmailAddress]
        public string ? EmailAddress {get; set;} 

        public string ? Image { get; set;}

        public DateTime ? birthDay { get ; set;}

        public string? Password { get; set; }

        public string? Address { get; set;}

        public string? Phone { get; set;}   


    }
}