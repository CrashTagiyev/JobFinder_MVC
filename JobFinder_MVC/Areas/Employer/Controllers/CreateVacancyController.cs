using AutoMapper;
using JobFinder_Application.Services;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Domain.Users;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Bson;
using System.Runtime.CompilerServices;

namespace JobFinder_Presentation.Areas.Employer.Controllers
{
	[Area("Employer")]
	[Authorize(Roles = "Employer,Admin")]
	public class CreateVacancyController : Controller
	{

		private readonly VacancyServices _vacancyServices;
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string CompanyLogoFolderPath;
		public CreateVacancyController(VacancyServices vacancyServices,  UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
		{
			_vacancyServices = vacancyServices;
			_userManager = userManager;
			_webHostEnvironment = webHostEnvironment;
			CompanyLogoFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "CompanyLogoImages");
		}

		//Create vacancy page
		[HttpGet]
		public async Task<IActionResult> CreateVacancy()
		{
			await PopulateSelectListsAsync();
			return View();
		}


		//Creating vacancy
		[HttpPost]
		public async Task<IActionResult> CreateVacancy(VacancyVM vacancyVM)
		{

			if (ModelState.IsValid)
			{
				var newVacancy = await _vacancyServices.MakeNewVacancyAsync(CompanyLogoFolderPath, vacancyVM);

				var user = await _userManager.GetUserAsync(User);
				if (user is not null)
					newVacancy.User = user;

				if (newVacancy is not null)
					await _vacancyServices.CreateVacancyAsync(newVacancy, vacancyVM.CategoryId, vacancyVM.TagsIds!);

				return RedirectToAction("Jobs", "FindJob", new { area = "AllUsers" });
			}
			await PopulateSelectListsAsync();
			return View(vacancyVM);
		}



		//View data initilazing
		private async Task PopulateSelectListsAsync()
		{
			var tags = await _vacancyServices.GetTagsSelectListItemsAsync();
			var categories = await _vacancyServices.GetCategorySelectListItemsAsync();
			ViewData["tags"] = new MultiSelectList(tags, "Value", "Text");
			ViewData["newVacancyCategories"] = new SelectList(categories, "Value", "Text");
		}
	}
}
