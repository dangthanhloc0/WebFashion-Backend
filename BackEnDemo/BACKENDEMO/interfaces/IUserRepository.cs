using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;


namespace BACKENDEMO.interfaces
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllasync();

        Task<AppUser?> GetByIDasync(String Name);       
        Task<AppUser?>  UpdateUserAsync(String Name,UserDto userDto);

        Task<AppUser?> DeleteStockAsync(String Name);

        Task<bool> UserExsit(String name);

        Task<bool> ChangePassWord(ChangePassWordDto changePassWordDto, AppUser user);


    }
}