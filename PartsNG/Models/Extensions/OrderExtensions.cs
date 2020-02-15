using PartsNG.ViewModels;

namespace PartsNG.Models.Extensions
{
    public static class OrderExtensions
    {
        public static OrderViewModel ToViewModel(this Order order) => new OrderViewModel()
        {
            Id = order.Id,
            Count = order.Count,
            Part = order.Part?.ToViewModel(),
            User = order.User?.ToViewModel()
        };

        public static Order AssignToModel(this Order order, OrderViewModel viewModel)
        {
            order.Count = viewModel.Count;
            return order;
        }
    }
}
