using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Services;
using Talabat.Repository.Identity;
using Talabat.Service;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TalabatAPIs.Extentions
{
    public static class IdentityServicesExtention
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ITokenServices, TokenService>();
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //options.Password.RequireDigit = true;
                //options.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            // بسئل التوكن لو جاي من الفرونت لو اللي الريكوست اللي جاي نوع بيرير ولا لا 
            services.AddAuthentication(/*JwtBearerDefaults.AuthenticationScheme*/options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            } )
               
                
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:Validissuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:validAuience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                };
                });
            return services;
        }
    }
}
