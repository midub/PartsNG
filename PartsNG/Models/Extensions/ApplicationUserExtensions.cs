using System.Linq;
using PartsNG.ViewModels;

namespace PartsNG.Models.Extensions
{
    public static class ApplicationUserExtensions
    {
        public static UserViewModel ToViewModel(this ApplicationUser user) => new UserViewModel()
        {
            Id = user.Id,
            UserName = user.UserName,
            Orders = user.Orders.Select(o => o.ToViewModel()).ToList()
        };

        public static ApplicationUser AssignToModel(this ApplicationUser user, UserViewModel viewModel)
        {
            user.UserName = viewModel.UserName;
            return user;
        }
    }
}
