using System.ComponentModel.DataAnnotations;

namespace WebApi.Model.User
{
    public class EmailCheckDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
