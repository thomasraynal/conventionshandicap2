using ConventionsHandicap.EntityFramework;

namespace ConventionsHandicap.Model.Contracts
{
    public interface IConventionsHandicapFeature
    {
        string Icon { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
        ICollection<ConventionsHandicapWorkspace>? Workspaces { get;  }

    }
}