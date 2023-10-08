using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public partial class Property
    {
        public Property(string code, string? value)
        {
            Code = code;
            Value = value;
        }
    }
}
