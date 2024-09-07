using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;



namespace BACKENDEMO.Mappers
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