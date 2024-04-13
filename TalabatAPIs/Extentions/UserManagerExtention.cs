using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.Core.Entities.Identity;

namespace TalabatAPIs.Extentions
{
    public static class UserManagerExtention
    {
        public static async Task<AppUser?> FindUserWithAdressAsync(this UserManager<AppUser> userManager,ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(U =>U.address).FirstOrDefaultAsync(U => U.Email == email);
            return user;
        }
    }
}
