using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace CodeGen
{
    public class CodeGenSpecProduct
    {
        [YamlMember(Alias = "appName")]
        public string AppName { get; set; }
        [YamlMember(Alias = "appNamespace")]
        public string AppNamespace { get; set; }
        [YamlMember(Alias = "appProjectReferences")]
        public string[] AppProjectReferences { get; set; }
        [YamlMember(Alias = "appPackageReferences")]
        public string[] AppPackageReferences { get; set; }
    }

    public class CodeGenSpec
    {
        [YamlMember(Alias ="x-product")]
        [JsonProperty("x-product")]
        public CodeGenSpecProduct CodeGenSpecProduct { get; set; }
    }
}
