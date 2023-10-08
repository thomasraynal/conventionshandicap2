using ConventionsHandicap.Model;
using Microsoft.AspNetCore.Identity;

namespace ConventionsHandicap.EntityFramework
{
    public class ConventionsHandicapUser : IdentityUser<Guid>, IConventionsHandicapUser
    {
        public Guid UserId => Id;

        public string UserEmail => Email;

        public bool UserMailConfirmed => EmailConfirmed;

        public string? UserTemporaryPassword { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ConventionsHandicapUser user && Id.Equals(user.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
