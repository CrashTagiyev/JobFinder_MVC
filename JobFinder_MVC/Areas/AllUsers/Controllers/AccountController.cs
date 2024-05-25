using AutoMapper;
using JobFinder_Domain.Users;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder_Presentation.Areas.AllUsers.Controllers
{
	[Area("AllUsers")]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;


		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
			if (!ModelState.IsValid)
			{
				return View(registerVM);
			}

			var newUserAccount = (AppUser)registerVM;
			var createdIdentityResult = await _userManager.CreateAsync(newUserAccount, registerVM.PasswordHash!);
			if (createdIdentityResult.Succeeded)
			{
				await _userManager.AddToRoleAsync(newUserAccount, "Employer");
				return Redirect("/AllUsers/Home/Index");
			}
			else
				foreach (var error in createdIdentityResult.Errors)
					ModelState.AddModelError("All", error.Description);

			return View(registerVM);
		}


		[HttpGet]
		public IActionResult LogIn(string? ReturnUrl = null)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(LogInVM logInVM)
		{
			if (!ModelState.IsValid)
				return View(logInVM);

			var findUser = await _userManager.FindByEmailAsync(logInVM.Email!);

			if (findUser is null)
			{
				ModelState.AddModelError("All", "User not found");
				return View(logInVM);
			}

			var result = await _userManager.CheckPasswordAsync(findUser, logInVM.Password!);

			if (!result)
			{
				ModelState.AddModelError("All", "Password is wrong");
				return View(logInVM);
			}

			await _signInManager.SignInAsync(findUser, true);


			return Redirect("/AllUsers/Home/Index");
		}

		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return Redirect("/AllUsers/Home/Index");
		}
	}
}
