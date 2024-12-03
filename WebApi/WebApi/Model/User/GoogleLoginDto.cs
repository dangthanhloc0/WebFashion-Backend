using System.ComponentModel.DataAnnotations;

namespace WebApi.Model.User
{
    public class GoogleLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NameOfUser { get; set; }  
    }

}
