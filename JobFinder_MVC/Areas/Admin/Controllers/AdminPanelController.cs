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
		public IActionResult CreateCategory()
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
			var categoryVM = await _adminService.GetCategoryByIdAsync(id);

			var updateVm = new AdminUpdateCategoryVM { Id = categoryVM.Id, Name = categoryVM!.Name! };

			return View(updateVm);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCategory(AdminUpdateCategoryVM categoryVM)
		{
			await _adminService.UpdateCategoryAsync(categoryVM);
			return RedirectToAction("GetCategories");
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


		[HttpGet]
		public IActionResult CreateTag()
		{
			return RedirectToAction("GetTags");
		}

		[HttpPost]
		public async Task<IActionResult> CreateTag(AdminCreateTagVM createTagVM)
		{
			await _adminService.AddTagAsync(createTagVM);
			return RedirectToAction("GetTags");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateTag(int id)
		{
			var tagVM = await _adminService.GetTagByIdAsync(id);

			var updateVm = new AdminUpdateCategoryVM { Id = tagVM.Id, Name = tagVM!.Name! };

			return View(updateVm);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTag(AdminUpdateTagVM tagVM)
		{
			await _adminService.UpdateTagAsync(tagVM);
			return RedirectToAction("GetTags");
		}


		[HttpPost]
		public async Task<IActionResult> DeleteTag(int id)
		{
			await _adminService.DeleteTagAsync(id);
			return RedirectToAction("GetTags");
		}
	

	}
}
