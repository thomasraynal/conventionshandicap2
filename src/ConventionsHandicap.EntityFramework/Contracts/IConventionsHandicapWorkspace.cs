using ConventionsHandicap.EntityFramework;

namespace ConventionsHandicap.Model.Contracts
{
    public interface IConventionsHandicapWorkspace
    {
        Guid Id { get; }
        Uri? Logo { get; }
        string Name { get; }
        ICollection<ConventionsHandicapFeature> Features { get; }

        string GetWorkspaceUserRoleKey(ConventionsHandicapUserRole userRole);
    }
}