using PartsNG.Models;
using System.Text.Json.Serialization;

namespace PartsNG.ViewModels
{
    /// <summary>
    /// Transport entity of Package
    /// </summary>
    public class PackageViewModel
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
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PartType PartType { get; set; }
    }
}