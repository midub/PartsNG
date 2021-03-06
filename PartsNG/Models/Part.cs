﻿using System.Collections.Generic;

namespace PartsNG.Models
{
    /// <summary>
    /// Part domain entity
    /// </summary>
    public class Part
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
        /// Currently available part count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Id of part's package
        /// </summary>
        public int? PackageId { get; set; }

        /// <summary>
        /// Associated Package entity
        /// </summary>
        public Package Package { get; set; }

        /// <summary>
        /// Where you can buy the part
        /// </summary>
        public string BuyLink { get; set; }

        /// <summary>
        /// Where you can find the part
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// List of associated PartProperties
        /// </summary>
        public ICollection<PartProperty> PartProperties { get; set; }

    }
}
