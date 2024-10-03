/*
using Libs.Data;
using Libs.Entity;

using Microsoft.AspNetCore.Identity;


namespace Libs.Repositoory
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllasync();

        Task<AppUser?> GetByIDasync(String Name);
        Task<AppUser?> UpdateUserAsync(String Name, UserDto userDto);

        Task<AppUser?> DeleteStockAsync(String Name);

        Task<bool> UserExsit(String name);

        Task<bool> ChangePassWord(ChangePassWordDto changePassWordDto, AppUser user);


    }
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
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
            return User != null ? true : false;
        }

        public async Task<bool> ChangePassWord(ChangePassWordDto changePassWordDto, AppUser user)
        {
            var result = await _useManager.ChangePasswordAsync(user, changePassWordDto.OldPassword, changePassWordDto.NewPassword);

            if (result.Succeeded)
            {

                return true;
            }
            return false;
        }

    }
}*/