using System;
using System.Collections.Generic;
using System.Text;

namespace PartsNG.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PartType PartType { get; set; }

    }
}
