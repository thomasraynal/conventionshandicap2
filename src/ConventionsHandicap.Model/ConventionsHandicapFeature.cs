using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model.Contracts;
using Newtonsoft.Json;

namespace ConventionsHandicap.Model
{
    public class ConventionsHandicapFeature : IConventionsHandicapFeature
    {
        public ConventionsHandicapFeature()
        {
            Workspaces = new List<ConventionsHandicapWorkspace>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }

        [JsonIgnore]
        public ICollection<ConventionsHandicapWorkspace> Workspaces { get; set; }
    }
}
