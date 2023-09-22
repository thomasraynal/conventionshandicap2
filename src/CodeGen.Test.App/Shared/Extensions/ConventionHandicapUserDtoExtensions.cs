using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;

namespace ConventionsHandicap.App.Shared.Extensions
{
    public static class ConventionHandicapUserDtoExtensions
    {
        public static UserDto ToUserDto(this ConventionsHandicapUser conventionsHandicapUser)
        {
            return new UserDto(conventionsHandicapUser.Id, conventionsHandicapUser.Email, conventionsHandicapUser.EmailConfirmed);
        }
    }
}
