using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JobFinder_Application.Services.AdminServices;
using JobFinder_Domain.ViewModels.AdminViewModels;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;

namespace JobFinder_Presentation.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class AdminPanelController : Controller
	{

		private readonly AdminService _adminService;

		public AdminPanelController(AdminService adminService)
		{
			_adminService = adminService;
		}


		[HttpGet]
		public IActionResult GetAdminPanel()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetVacancies()
		{
			var vacancies = await _adminService.GetAllVacanciesAsync();

			return View(vacancies.ToList());
		}

		[HttpGet]
		public async Task<IActionResult> UpdateVacancy(int id)
		{
			var vacancyVM = await _adminService.GetVacancyByIdAsync(id);

			if (vacancyVM is not null)
				return View(vacancyVM);

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateVacancy(AdminVacancyVM vacancyVM)
		{
				if (vacancyVM is not null)
				{
					await _adminService.UpdateVacancyAsync(vacancyVM);
					return RedirectToAction("GetVacancies");

				}

			return View(vacancyVM);

		}

		public async Task<IActionResult> DeleteVacancy(int id)
		{
			var isDeleted = await _adminService.DeleteVacancyAsync(id);

			if (isDeleted)
				return RedirectToAction("GetVacancies");

			return NotFound();
		}


		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await _adminService.GetAllCategoriesAsync();

			return View(categories.ToList());
		}


		[HttpGet]
		public  IActionResult CreateCategory()
		{
			return RedirectToAction("GetCategories");
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(AdminCreateCategoryVM createCategoryVM)
		{
			await _adminService.AddCategoryAsync(createCategoryVM);
			return RedirectToAction("GetCategories");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var categoryVM = _adminService.GetCategoryByIdAsync(id);
			if (categoryVM is not null)
			{
				await _adminService.UpdateCategoryAsync(categoryVM);
				return RedirectToAction("GetVacancies");

			}

			return View(categoryVM);
		}


		[HttpPost]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _adminService.DeleteCategoryAsync(id);
			return RedirectToAction("GetCategories");
		}
		public async Task<IActionResult> GetTags()
		{
			var tags = await _adminService.GetAllTagsAsync();

			return View(tags.ToList());
		}




	}
}
