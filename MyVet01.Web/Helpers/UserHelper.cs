using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyVet01.Web.Data.Entities;

namespace MyVet01.Web.Helpers
{
    public class UserHelper : IUserHelper
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
            //LO DE ARRIBA ES POQUE NO TENERMOS ROLES PERSONAIZADOS PERO SÍ USUARIOS
            
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }


        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            //throw new NotImplementedException();
            return await _userManager.CreateAsync(user, password); 
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            //throw new NotImplementedException();
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            //throw new NotImplementedException();
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });

            }




        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            //throw new NotImplementedException();
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            // throw new NotImplementedException();
            return await _userManager.IsInRoleAsync(user, roleName);
        }
    }
}
