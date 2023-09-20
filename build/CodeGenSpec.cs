using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeGen
{
    public class CodeGenSpecProduct
    {
        public string AppName { get; set; }
        public string AppNamespace { get; set; }
        public string[] AppUsing { get; set; }
        public string[] AppProjectReferences { get; set; }
        public string[] AppPackageReferences { get; set; }
    }

    public class CodeGenSpec
    {
        [JsonProperty("x-product")]
        public CodeGenSpecProduct CodeGenSpecProduct { get; set; }
    }
}
