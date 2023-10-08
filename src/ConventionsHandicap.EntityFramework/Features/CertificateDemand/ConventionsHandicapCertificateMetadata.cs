using ConventionsHandicap.Model.Features.CertificateDemand;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
    public class ConventionsHandicapCertificateMetadata
    {
        public ConventionsHandicapCertificateMetadata(string code, string label, string information, string group, Type dataType, ConventionsHandicapMetadataType metadataType)
        {
            Code = code;
            Label = label;
            Information = information;
            Group = group;
            DataType = dataType;
            MetadataType = metadataType;
        }

        public ConventionsHandicapCertificateMetadata(string code, string label, string information, string group, string dataType, string metadataType)
        {
            Code = code;
            Label = label;
            Information = information;
            Group = group;
            DataType = Type.GetType(dataType);
            MetadataType = (ConventionsHandicapMetadataType)Enum.Parse(typeof(ConventionsHandicapMetadataType), metadataType);
        }


        [JsonIgnore]
        public Type DataType { get; }
        public string Code { get; }
        public string Label { get; }
        public string Information { get; }
        public string Group { get; }
        public ConventionsHandicapMetadataType MetadataType { get; }
    }
}
