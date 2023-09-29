using ConventionsHandicap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap
{
    public partial class ConventionsHandicapController
    {
        protected override Task<CreateUserResponseBuilder> CreateUserInternalAsync(CreateUserRequest requestBody)
        {
            return base.CreateUserInternalAsync(requestBody);
        }

        protected override Task<DeleteUserResponseBuilder> DeleteUserInternalAsync(DeleteUserRequest requestBody)
        {
            return base.DeleteUserInternalAsync(requestBody);
        }

        protected override Task<GetCurrentUserResponseBuilder> GetCurrentUserInternalAsync()
        {
            return base.GetCurrentUserInternalAsync();
        }

        protected override Task<GetUsersResponseBuilder> GetUsersInternalAsync()
        {
            return base.GetUsersInternalAsync();
        }

        protected override Task<UpdateUserResponseBuilder> UpdateUserInternalAsync(UpdateUserRequest requestBody)
        {
            return base.UpdateUserInternalAsync(requestBody);
        }

    }
}
