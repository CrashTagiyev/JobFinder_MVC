using AutoMapper;
using JobFinder_Application.BuisnessLogicClasses;
using JobFinder_Application.Services;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.FindJobViewModels;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.JobDetailViewModels;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobFinder_Presentation.Areas.AllUsers.Controllers
{
	[Area("AllUsers")]
	public class FindJobController : Controller
	{
		private readonly JobFinderServices _jobFinderServices;
		public FindJobController( JobFinderServices jobFinderServices)
		{
			_jobFinderServices = jobFinderServices;
			ViewData["filterOptions"] = new JobSearchFilterOptions();
		}

		[HttpGet]
		public async Task<IActionResult> Jobs(JobSearchFilterOptions options)
		{
			var tags = await _jobFinderServices.GetTagsSelectListItemsAsync();
			var categories = await _jobFinderServices.GetCategorySelectListItemsAsync();
			var jobs = await _jobFinderServices.GetPopulatedJobsAsync(options);

			ViewData["tags"] = new MultiSelectList(tags, "Value", "Text");
			ViewData["filterCategories"] = new SelectList(categories, "Value", "Text");

			return View(jobs);
		}



		[HttpGet("AllUsers/FindJob/JobDetail/{id:int}")]
		public async Task<IActionResult> JobDetail(int id)
		{

			var jobDetail = await _jobFinderServices.GetJobDetailVMAsync(id);

			if (jobDetail is null)
				return NotFound();

			return View(jobDetail);
		}



	}
}
