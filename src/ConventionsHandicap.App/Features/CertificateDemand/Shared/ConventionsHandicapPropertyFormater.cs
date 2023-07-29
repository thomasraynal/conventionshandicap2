using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Features.CertificateDemand.Shared
{
    public static class ConventionsHandicapPropertyFormater
    {
        public static readonly IReadOnlyDictionary<string, Action<Property>> Transformers = new Dictionary<string, Action<Property>>()
    {
      { "childLastName", ToUpperCase },
      { "schoolMainTeacherLastName", ToUpperCase },
      { "schoolPrincipalLastName", ToUpperCase },
      { "legalRepresentant1LastName", ToUpperCase },
      { "legalRepresentant2LastName", ToUpperCase },
      { "careGiver1LastName", ToUpperCase },
      { "careGiver1FatherLastName", ToUpperCase },
      { "careGiver1MotherLastName", ToUpperCase },
      { "careGiver2LastName", ToUpperCase },
      { "careGiver2FatherLastName", ToUpperCase },
      { "careGiver2MotherLastName", ToUpperCase },
      { "supervisorLastName", ToUpperCase }
    };

        public static readonly IReadOnlyDictionary<string, Action<Property>> Checkers = new Dictionary<string, Action<Property>>()
    {
      { "schoolMail", CheckMail },
      { "legalRepresentant1Mail", CheckMail },
      { "legalRepresentant2Mail", CheckMail },
      { "careGiver1Mail", CheckMail },
      { "careGiver2Mail", CheckMail },
      { "supervisorMail", CheckMail },
      { "childDateOfBirth", CheckDate },
      { "careGiver1DateOfBirth", CheckDate },
      { "careGiver2DateOfBirth", CheckDate },
      { "dateCDAPHNotification", CheckDate },
      { "dateCDAPHNotificationValidUntil", CheckDate },
    };

        public static void ToUpperCase(this Property property)
        {
            if (null == property || null == property.Value) return;

            property.Value = property.Value.ToUpper();
        }

        public static void CheckMail(this Property property)
        {
            if (null == property || null == property.Value) return;

            var regexPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            var isMatch = Regex.IsMatch(property.Value, regexPattern, RegexOptions.IgnoreCase);

            if (!isMatch)
                throw new ConventionsHandicapBadRequestException($"{property.Value} is not a valid email.");

        }

        public static void CheckDate(this Property property)
        {
            if (null == property || null == property.Value) return;

            var isDate = DateTime.TryParse(property.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

            if (!isDate)
                throw new ConventionsHandicapBadRequestException($"{property.Value} is not a valid date.");
        }
    }
}
