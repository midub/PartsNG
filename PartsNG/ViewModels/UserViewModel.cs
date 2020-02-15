using System.Collections.Generic;

namespace PartsNG.ViewModels
{
    /// <summary>
    /// Transport entity of ApplicationUser
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User's selected name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Orders associated with the user
        /// </summary>
        public ICollection<OrderViewModel> Orders { get; set; }

    }
}