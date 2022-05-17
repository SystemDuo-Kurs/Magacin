using Magacin.Areas.Identity.Data;
using Magacin.Services;

namespace Magacin.ViewModels
{
    public interface IUserVM
    {
        Task RegisterAsync();
    }

    public class UserVM : IUserVM
    {
        private IUserService UserService { get; init; }
        public Magacioner Magacioner { get; set; } = new();
        public UserVM (IUserService userService)
        {
            UserService = userService;
        }

        public async Task RegisterAsync()
        {
            await UserService.RegisterAsync(Magacioner);
            Magacioner = new();
        }
    }
}
