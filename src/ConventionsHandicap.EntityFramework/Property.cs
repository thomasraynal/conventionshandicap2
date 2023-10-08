using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public class Property
    {
        public Property()
        {
        }

        public Property(string code, string? value)
        {
            Code = code;
            Value = value;
        }

        [Required]
        public string Code { get; set; }
        public string? Value { get; set; }
    }
}
