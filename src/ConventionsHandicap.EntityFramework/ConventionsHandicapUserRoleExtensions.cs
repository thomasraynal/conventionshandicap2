using ConventionsHandicap.EntityFramework;
using System.Linq;

namespace ConventionsHandicap.Model
{

    public static class ConventionsHandicapUserRoleExtensions
    {
        public static bool IsNone(this ConventionsHandicapUserRole userRole)
        {
            return userRole == ConventionsHandicapUserRole.None;
        }

        public static bool IsAdministrator(this ConventionsHandicapUserRole userRole)
        {
            return userRole == ConventionsHandicapUserRole.Administrator;
        }

        public static bool IsManager(this ConventionsHandicapUserRole userRole)
        {
            return userRole == ConventionsHandicapUserRole.Manager;
        }

        public static bool IsUser(this ConventionsHandicapUserRole userRole)
        {
            return userRole == ConventionsHandicapUserRole.User;
        }

        public static bool IsNone(this ConventionsHandicapUserRole[] userRoles)
        {
            return userRoles.Any(userRole => userRole == ConventionsHandicapUserRole.None);
        }

        
    }

}
