namespace SportsStore.Models
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class IdentitySeedData
    {
        private const string adminPassword = "Secret123$";

        private const string adminUser = "Admin";

        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            
            var user = await userManager.FindByIdAsync(adminUser);
            if (user == null) user = new IdentityUser(adminUser);
            await userManager.CreateAsync(user, adminPassword);
        }
    }
}