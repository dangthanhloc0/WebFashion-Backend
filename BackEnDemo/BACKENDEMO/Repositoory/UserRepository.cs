using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Stock;
using BACKENDEMO.Dtos.User;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BACKENDEMO.Repositoory
{
    public class UserRepository : IUserRepository
    {

        private readonly AppplicationDBContext _context;
        private readonly UserManager<AppUser> _useManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserRepository(AppplicationDBContext context, UserManager<AppUser> useManager)
        {
            _context = context;
            _useManager = useManager;
        }

        public Task<AppUser?> DeleteStockAsync(string Name)
        {
            return null;
        }

        public async Task<List<AppUser>> GetAllasync()
        {
           var ListUser = _useManager.Users.ToList();  
            return ListUser;
        }

        public async Task<AppUser?> GetByIDasync(string Name)
        {
            var User = await _useManager.FindByNameAsync(Name);
            return User;
        }

        public async Task<AppUser?> UpdateUserAsync(String Name, UserDto userDto)
        {
            var User = await _useManager.FindByNameAsync(Name);
            User.UserName = userDto.Username;   
            var result = await _useManager.UpdateAsync(User);
            if (!result.Succeeded)
            {
               
            }
            return User; 
        }

        public async Task<bool> UserExsit(string Name)
        {
            var User = await _useManager.FindByNameAsync(Name);
            return User != null? true : false;
        }

        public async Task<bool> ChangePassWord(ChangePassWordDto changePassWordDto,AppUser user)
        {
            var result = await _useManager.ChangePasswordAsync(user, changePassWordDto.OldPassword, changePassWordDto.NewPassword);

            if (result.Succeeded)
            {

                return true;
            }
            return false;
        }

    }
}