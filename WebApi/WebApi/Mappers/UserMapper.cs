



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
                Username = AppUser.NameOfUser,    
               /* Password = AppUser.PasswordHash,*/
                /*EmailAddress = AppUser.Email,*/
                Image = AppUser.Image,
                birthDay = AppUser.birthDay,
                Address = AppUser.Address,
                Phone = AppUser.Phone,
                
            };
        }


    }
}