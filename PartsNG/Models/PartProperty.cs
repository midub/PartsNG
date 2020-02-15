namespace PartsNG.Models
{
    /// <summary>
    /// PartProperty domain join entity
    /// </summary>
    public class PartProperty
    {
        /// <summary>
        /// Identifier of part
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// Associated Part entity
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// Identifier of property
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Associated Property entity
        /// </summary>
        public Property Property { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

    }
}
