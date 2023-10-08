using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public enum ConventionsHandicapCertificateDemandStatus
    {

        [EnumMember(Value = "A COMPLETER")]
        ToComplete,
        [EnumMember(Value = "A VALIDER")]
        ToValidate,
        [EnumMember(Value = "VALIDÉ")]
        Validated
    }
}
