using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Shared
{
    public class ConventionsHandicapUserAdmin : ConventionsHandicapUser
    {
        private ConventionsHandicapUserAdmin()
        {
        }

        public static ConventionsHandicapUser Self => new ConventionsHandicapUserAdmin();

    }
}
