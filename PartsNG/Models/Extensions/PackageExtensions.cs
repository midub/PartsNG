using PartsNG.ViewModels;

namespace PartsNG.Models.Extensions
{
    public static class PackageExtensions
    {
        public static PackageViewModel ToViewModel(this Package package) => new PackageViewModel()
        {
            Id = package.Id,
            Name = package.Name,
            PartType = package.PartType
        };

        public static Package AssignToModel(this Package package, PackageViewModel viewModel)
        {
            package.Name = viewModel.Name;
            package.PartType = viewModel.PartType;
            return package;
        }
    }
}
