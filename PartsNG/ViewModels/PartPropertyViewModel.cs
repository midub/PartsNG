namespace PartsNG.ViewModels
{
    /// <summary>
    /// Transport entity of PartProperty.
    /// </summary>
    public class PartPropertyViewModel
    {
        /// <summary>
        /// Identifier of associated part
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// Identifier of associated property
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}
