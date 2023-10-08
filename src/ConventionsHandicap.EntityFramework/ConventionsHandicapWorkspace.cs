using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Contracts;

namespace ConventionsHandicap.EntityFramework
{
    public class ConventionsHandicapWorkspace : IConventionsHandicapWorkspace
    {
        public ConventionsHandicapWorkspace()
        {
            Features = new List<ConventionsHandicapFeature>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri? Logo { get; set; }

        public ICollection<ConventionsHandicapFeature> Features { get; set; }

        public string GetWorkspaceUserRoleKey(ConventionsHandicapUserRole userRole)
        {
            return ConventionsHandicapIdentityRole.GetRoleName(userRole, Id);
        }
    }
}
