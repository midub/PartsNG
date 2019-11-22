using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartsNG.Models
{
    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public int? PackageId { get; set; }

        [JsonIgnore]

        public Package Package { get; set; }

        public string BuyLink { get; set; }

        public string Position { get; set; }

        public ICollection<PartProperty> PartProperties { get; set; }

    }
}
