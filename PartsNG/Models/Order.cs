using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PartsNG.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int PartId { get; set; }

        [JsonIgnore]
        public Part Part { get; set; }

        public int Count { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
