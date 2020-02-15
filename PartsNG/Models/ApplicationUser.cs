using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PartsNG.Models
{
    /// <summary>
    /// User domain entity
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Orders associated with user
        /// </summary>
        public ICollection<Order> Orders { get; set; }

    }
}
