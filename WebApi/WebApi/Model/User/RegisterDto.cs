using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model.User
{
    public class RegisterDto
    {   
        [Required]
        public string  Username {get; set;}      

        [Required]
        [EmailAddress]
        public string  EmailAddress {get; set;} 

        [Required]
        public string  Password {get; set; }
        [Required]
        public string NameOfUser { get; set;}
        [Required]
        public bool ResigterWithgoogle { get; set; } 




    }
}