using Microsoft.AspNetCore.Identity;

namespace TP_WEB.Areas.Identity.Data
{
    public static class IdentityManager
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Administrateur", "Utilisateur" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            IdentityUser? user = await UserManager.FindByEmailAsync("courrielTI@cstjean.qc.ca");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "courrielTI@cstjean.qc.ca",
                    Email = "courrielTI@cstjean.qc.ca",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                };
                await UserManager.CreateAsync(user, "2C3P@ssw0rd");
            }
            await UserManager.AddToRoleAsync(user, "Administrateur");
        }

    }
}
