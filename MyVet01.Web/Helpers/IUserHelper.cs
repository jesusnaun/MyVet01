using Microsoft.AspNetCore.Identity;
using MyVet01.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Helpers
{
    interface IUserHelper
    {
        //SE AÑADEN MÉTodoS  A LA INTERFAZ DE TABLAS QUE NO CONTROLAMOS

        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);

    }
}
