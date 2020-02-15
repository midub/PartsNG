using PartsNG.ViewModels;

namespace PartsNG.Models.Extensions
{
    public static class PropertyExtensions
    {
        public static PropertyViewModel ToViewModel(this Property property) => new PropertyViewModel()
        {
            Id = property.Id,
            Name = property.Name
        };
    }
}
