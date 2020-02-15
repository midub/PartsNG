using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartsNG.ViewModels;

namespace PartsNG.Models.Extensions
{
    public static class PartPropertyExtensions
    {
        public static PartPropertyViewModel ToViewModel(this PartProperty partProperty) => new PartPropertyViewModel()
        {
            PartId = partProperty.PartId,
            PropertyId = partProperty.PropertyId,
            Value = partProperty.Value
        };

        public static PartProperty AssignToModel(this PartProperty partProperty, PartPropertyViewModel viewModel)
        {
            partProperty.PartId = viewModel.PartId;
            partProperty.PropertyId = viewModel.PropertyId;
            partProperty.Value = viewModel.Value;
            return partProperty;
        }
    }
}
