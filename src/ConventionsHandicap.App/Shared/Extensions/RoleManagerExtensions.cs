using ConventionsHandicap.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Shared.Extensions
{
    public static class RoleManagerExtensions
    {
        public static async Task<ConventionsHandicapIdentityRole?> GetConventionsHandicapIdentityRole(this RoleManager<ConventionsHandicapIdentityRole> roleManager, string roleName)
        {
            return await roleManager.Roles.FirstOrDefaultAsync(role => role.Name == roleName);
        }

        public static async Task<ConventionsHandicapIdentityRole[]> GetConventionsHandicapIdentityRoles(this RoleManager<ConventionsHandicapIdentityRole> roleManager, IEnumerable<string> roleNames)
        {
            return await roleManager.Roles.Where(role => roleNames.Contains(role.Name)).Distinct().ToArrayAsync();
        }

    }
}
