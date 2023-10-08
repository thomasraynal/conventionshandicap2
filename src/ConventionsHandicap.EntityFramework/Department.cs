using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public class Department
    {
        public string Name { get; set; }

        [JsonIgnore]
        public Academy Academy { get; set; }
    }
}
