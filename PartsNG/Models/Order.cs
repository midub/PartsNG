
namespace PartsNG.Models
{
    /// <summary>
    /// Order domain entity
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of part to order
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// Associated part entity
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// Count to order
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Identifier of user who made order
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Associated user entity
        /// </summary>
        public ApplicationUser User { get; set; }
    }
}
