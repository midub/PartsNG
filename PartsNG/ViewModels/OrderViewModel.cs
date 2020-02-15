namespace PartsNG.ViewModels
{
    /// <summary>
    /// Transport entity of Order
    /// </summary>
    public class OrderViewModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Associated part
        /// </summary>
        public PartViewModel Part { get; set; }

        /// <summary>
        /// Count to order
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// User who made the order
        /// </summary>
        public UserViewModel User { get; set; }
    }
}
