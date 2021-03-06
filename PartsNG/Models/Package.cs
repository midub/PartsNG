﻿namespace PartsNG.Models
{
    /// <summary>
    /// Order domain entity
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of package
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of part (SMD, THD etc.)
        /// </summary>
        public PartType PartType { get; set; }

    }
}
