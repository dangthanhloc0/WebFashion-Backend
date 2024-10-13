using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model.User
{
    public class UserInformation
    {   

        public string ? Image { get; set;}

        public string ? Year { get ; set;}
        public string ? Month { get; set; }
        public string ? Day { get; set; }


    }
}