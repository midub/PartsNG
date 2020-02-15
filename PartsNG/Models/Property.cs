using System.Collections.Generic;

namespace PartsNG.Models
{
    /// <summary>
    /// Property domain entity
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of associated PartProperty join entities.
        /// </summary>
        public ICollection<PartProperty> PartProperties { get; set; }
    }
}
