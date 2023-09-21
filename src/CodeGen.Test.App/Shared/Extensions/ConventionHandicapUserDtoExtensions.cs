using ConventionsHandicap.App.Controllers.Dto;
using ConventionsHandicap.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
