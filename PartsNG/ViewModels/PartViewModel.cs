using System.Collections.Generic;

namespace PartsNG.ViewModels
{
    /// <summary>
    /// Transport entity of Part
    /// </summary>
    public class PartViewModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of part
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current count of part
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Package of part
        /// </summary>
        public PackageViewModel Package { get; set; }

        /// <summary>
        /// Link where part can be bought
        /// </summary>
        public string BuyLink { get; set; }

        /// <summary>
        /// Where you can find the part
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Associated properties with the part
        /// </summary>
        public ICollection<PartPropertyViewModel> Properties { get; set; }
    }
}
