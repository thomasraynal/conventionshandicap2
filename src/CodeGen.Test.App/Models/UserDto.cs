using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public partial class UserDto
    {
        public UserDto(Guid id, string email, bool emailConfirmed)
        {
            Id = id;
            Email = email;
            MailConfirmed = emailConfirmed;
        }
    }
}
