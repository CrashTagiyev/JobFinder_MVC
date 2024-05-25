using JobFinder_Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace JobFinder_Presentation.Middlewares
{
    public class AuthorizationRouterMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;
        private readonly RoleManager<AppUser> _roleManager;

        public AuthorizationRouterMiddleware(RequestDelegate next, SignInManager<AppUser> signIn, RoleManager<AppUser> roleManager, UserManager<AppUser> userManager )
        {
            _next = next;
            _signManager = signIn;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity is not null && context.User.Identity.IsAuthenticated)
            {
                var currentUser = await _signManager.UserManager.GetUserAsync(context.User);

                if (currentUser != null)
                {
                    if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
                    {
                        context.Response.Redirect("/Admin/AdminPanel/Panel");
                        return;
                    }
                    else if (await _userManager.IsInRoleAsync(currentUser, "Employer"))
                    {
                        context.Response.Redirect("/Employer/Home/Index");
                    }
                    // Add more roles and routes as needed
                }
            }

            await _next(context);
        }


    }
}
