using Microsoft.AspNetCore.Identity;

namespace ConventionsHandicap.EntityFramework
{
    public class ConventionsHandicapIdentityRole : IdentityRole<Guid>
    {
        public static string GetRoleName(ConventionsHandicapUserRole conventionsHandicapUserRole, Guid? workspaceId)
        {
            return workspaceId == null ? $"{conventionsHandicapUserRole}" : $"{conventionsHandicapUserRole}-{workspaceId}";
        }

        public ConventionsHandicapIdentityRole()
        {
        }

        public ConventionsHandicapIdentityRole(ConventionsHandicapUserRole conventionsHandicapUserRole, Guid? workspaceId)
        {
            Id = Guid.NewGuid();
            WorkspaceId = workspaceId;
            UserRole = conventionsHandicapUserRole;
            Name = GetRoleName(conventionsHandicapUserRole, workspaceId);
        }

        public ConventionsHandicapIdentityRole(string roleName) : base(roleName)
        {
            Id = Guid.NewGuid();
        }

        public Guid? WorkspaceId { get; set; }

        public ConventionsHandicapUserRole UserRole { get; set; }

    }
}
