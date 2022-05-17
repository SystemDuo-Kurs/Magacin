using Magacin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Magacin.Services
{
    public interface IUserService 
    {
        Task RegisterAsync(Magacioner magacioner);
    }
    public class UserService : IUserService
    {
        private UserManager<Magacioner> UserManager { get; init; }

        public UserService (UserManager<Magacioner> userManager)
        {
            UserManager = userManager;
        }

        public async Task RegisterAsync(Magacioner magacioner)
        {
            await UserManager.CreateAsync(magacioner, magacioner.ClearTextPassword);
        }
    }
}
