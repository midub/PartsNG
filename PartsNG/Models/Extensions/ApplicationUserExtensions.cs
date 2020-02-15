using PartsNG.ViewModels;

namespace PartsNG.Models.Extensions
{
    public static class ApplicationUserExtensions
    {
        public static UserViewModel ToViewModel(this ApplicationUser user) => new UserViewModel()
        {
            Id = user.Id,
            UserName = user.UserName,

        };
    }
}
