using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartsNG.Models
{
    public class PartProperty
    {
        public int PartId { get; set; }

        [JsonIgnore]
        public Part Part { get; set; }
        public int PropertyId { get; set; }

        [JsonIgnore]
        public Property Property { get; set; }
        public double Value { get; set; }

    }
}
