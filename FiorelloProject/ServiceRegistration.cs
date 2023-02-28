using System;
using FiorelloProject.DAL;
using FiorelloProject.Services.Basket;

namespace FiorelloProject
{
	public static class ServiceRegistration
	{
     
		public static void FiorelloProjectServiceRegistration(this IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			services.AddScoped<IBasketProductCount,BasketProductCount>();
        }
    }
}

