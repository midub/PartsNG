using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PartsNG.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PartType
    {
        None = 0,
        SMD = 1,
        THD = 2
    }
}
