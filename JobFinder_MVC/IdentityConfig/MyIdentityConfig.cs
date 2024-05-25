using JobFinder_Application.Services;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace JobFinder_Presentation.IdentityConfig
{
	public static class MyIdentityConfig
	{
		public static void ConfigureIdentityOptions(IdentityOptions option)
		{
			//User
			option.User.RequireUniqueEmail = true;
			//Password
			option.Password.RequiredLength = 6;
			option.Password.RequireUppercase = true;
			option.Password.RequireLowercase = true;
			option.Password.RequireDigit = true;
			option.Password.RequireNonAlphanumeric = false;
			//Lockout
			option.Lockout.MaxFailedAccessAttempts = 3;
		}


		public static void ConfigureIdentityCookie(CookieAuthenticationOptions options)
		{
			options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
			options.Cookie.MaxAge = TimeSpan.FromDays(1);	
		}
	}
}
