



using Libs.Entity;
using WebApi.Model.User;

namespace WebApi.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this AppUser AppUser)
        {
            return new UserDto
            {
                Username = AppUser.UserName,    
                Password = AppUser.PasswordHash,
                EmailAddress = AppUser.Email
            };
        }


    }
}