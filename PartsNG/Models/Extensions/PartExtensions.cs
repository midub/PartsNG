using PartsNG.ViewModels;
using System.Linq;

namespace PartsNG.Models.Extensions
{
    public static class PartExtensions
    {
        public static PartViewModel ToViewModel(this Part part) => new PartViewModel()
        {
            Id = part.Id,
            BuyLink = part.BuyLink,
            Count = part.Count,
            Name = part.Name,
            Package = part.Package?.ToViewModel(),
            Position = part.Position,
            Properties = part.PartProperties?.Select(pp => pp.Property?.ToViewModel()).ToList()
        };
    }
}
