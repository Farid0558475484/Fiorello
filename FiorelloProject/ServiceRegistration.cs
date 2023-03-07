using System;
using FiorelloProject.DAL;
using FiorelloProject.Models;
using FiorelloProject.Services.Basket;
using Microsoft.AspNetCore.Identity;

namespace FiorelloProject
{
	public static class ServiceRegistration
	{
     
		public static void FiorelloProjectServiceRegistration(this IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			//services.AddScoped<IBasketProductCount, BasketProductCount>();
			services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;

				options.User.RequireUniqueEmail = true;

				options.Lockout.AllowedForNewUsers = true;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}

