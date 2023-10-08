using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public class Academy
    {
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
