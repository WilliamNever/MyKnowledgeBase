using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Core3TEST.Models
{
    public class BaseModel
    {
        public virtual string Name { get; set; } = "AAA";
        public int Value { get; set; } = 33;
    }

    public class ExModel1 : BaseModel
    {
        public override string Name { get; set; } = "AAANxt";
        [JsonPropertyName("Value")][JsonExtensionData]
        public new string Value { get; set; } = "33XXX";
    }
}
