using ConventionsHandicap.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Shared.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<bool> IsAdministratorAsync(this UserManager<ConventionsHandicapUser> userManager, ConventionsHandicapUser conventionsHandicapUser)
        {
            var administrators = await userManager.GetUsersInRoleAsync($"{ConventionsHandicapUserRole.Administrator}");

            return administrators.Contains(conventionsHandicapUser);
        }
    }
}
