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
    }
}
