using Anabasis.Identity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public interface IConventionsHandicapUser : IHaveEmail
    {
        Guid UserId { get; }
        bool UserMailConfirmed { get; }
    }
}
