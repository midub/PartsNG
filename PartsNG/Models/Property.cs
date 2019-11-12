using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PartsNG.Models 
{
    public class Property
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PartProperty> PartProperties { get; set; }
    }
}
