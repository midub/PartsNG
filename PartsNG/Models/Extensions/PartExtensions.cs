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
            Properties = part.PartProperties?.Select(pp => pp.ToViewModel()).ToList()
        };

        public static Part AssignToModel(this Part part, PartViewModel viewModel)
        {
            part.BuyLink = viewModel.BuyLink;
            part.Count = viewModel.Count;
            part.Name = viewModel.Name;
            part.Position = viewModel.Position;
            part.PackageId = viewModel.Package.Id;
            return part;
        }
    }
}
