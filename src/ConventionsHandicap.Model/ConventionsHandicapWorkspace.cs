using ConventionsHandicap.Model;
using ConventionsHandicap.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.EntityFramework
{
    public class ConventionsHandicapWorkspace : IConventionsHandicapWorkspace
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri? Logo { get; set; }

        public ICollection<ConventionsHandicapFeature>? Features { get; set; }

        public string GetWorkspaceUserRoleKey(ConventionsHandicapUserRole userRole)
        {
            return $"{userRole}-{Id}";
        }
    }
}
