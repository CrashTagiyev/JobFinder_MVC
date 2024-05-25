using AutoMapper;
using JobFinder_Application.BuisnessLogicClasses;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.FindJobViewModels;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.JobDetailViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JobFinder_Application.Services
{
	public class JobFinderServices
	{
		private readonly IVacancyRepository _vacancyRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly ITagRepository _tagRepository;
		private readonly IMapper _mapper;
		public JobFinderServices(IVacancyRepository vacancyRepository, ICategoryRepository categoryRepository, ITagRepository tagRepository, IMapper mapper)
		{
			_vacancyRepository = vacancyRepository;
			_categoryRepository = categoryRepository;
			_tagRepository = tagRepository;
			_mapper = mapper;
		}
		public async Task<List<SelectListItem>> GetTagsSelectListItemsAsync()
		{
			var tags = await _tagRepository.GetAllAsync();
			var selectItemsTags = new List<SelectListItem>();

			if (tags != null && tags.Any()) { }
			foreach (Tag tag in tags)
				selectItemsTags.Add(new SelectListItem { Value = tag.Name, Text = tag.Name });

			return selectItemsTags;
		}

		public async Task<List<SelectListItem>> GetCategorySelectListItemsAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();
			var selectItemsCategories = new List<SelectListItem>();


			if (categories != null && categories.Any())
				foreach (Category cat in categories)
				{
					selectItemsCategories.Add(new SelectListItem { Value = cat.Name, Text = cat.Name });
				}

			return selectItemsCategories;
		}

		public async Task<JobDetailVM> GetJobDetailVMAsync(int id)
		{
			var vacancy = await _vacancyRepository.GetByIdAsync(id);
			if (vacancy is not null)
			{
				var jobDetailVM = _mapper.Map<JobDetailVM>(vacancy);
				jobDetailVM.Company = _mapper.Map<FindJobCompanyVM>(vacancy.Company);
				if (jobDetailVM is not null)
					return jobDetailVM;

			}
			return null!;
		}

		public async Task<List<FindJobViewModel>> GetPopulatedJobsAsync(JobSearchFilterOptions options)
		{
			var vacancies = await GetFilteredVacanciesAsync(options);
			List<FindJobViewModel> jobs = new List<FindJobViewModel>();
			if (vacancies != null && vacancies.Count > 0)
				foreach (Vacancy vacancy in vacancies)
				{
					var resultJob = _mapper.Map<FindJobViewModel>(vacancy);
					resultJob.CompanyVM = _mapper.Map<FindJobCompanyVM>(vacancy.Company);
					jobs.Add(resultJob);
				}

			return jobs;
		}
		public async Task<List<Vacancy>> GetFilteredVacanciesAsync(JobSearchFilterOptions options)
		{

			var vacancies = await _vacancyRepository.GetAllAsync();
			IEnumerable<Vacancy> enumVacancies = vacancies;
			if (options is not null && options.IsOptionsNullOrEmpty())
				if (vacancies.Count() > 0 && vacancies is not null)
				{
					//FIlter by search
					if (!string.IsNullOrEmpty(options.SearchedWord))
						enumVacancies = enumVacancies.Where(v =>
							v.Title!.Contains(options.SearchedWord, StringComparison.OrdinalIgnoreCase) ||
							v.JobDescription!.Contains(options.SearchedWord, StringComparison.OrdinalIgnoreCase) ||
							v.Company.CompanyName!.Contains(options.SearchedWord, StringComparison.OrdinalIgnoreCase) ||
							v.Company.CompanyInformation!.Contains(options.SearchedWord, StringComparison.OrdinalIgnoreCase) ||
							v.Category.Name!.Contains(options.SearchedWord, StringComparison.OrdinalIgnoreCase) ||
							v.Tags is not null && v.Tags!.Any(t => t.Name!.Contains(options.SearchedWord, StringComparison.OrdinalIgnoreCase))
							);

					//FIlter by category name
					if (!string.IsNullOrEmpty(options.CategoryName) && options.CategoryName != "All")
						enumVacancies = enumVacancies.Where(v => v.Category.Name!.Contains(options.CategoryName));

					//FIlter by job type
					if (options.JobType is not null && options.JobType.Any())
						enumVacancies = enumVacancies.Where(v => options.JobType!.Any(exp => exp == v.JobNature));

					//FIlter by experience
					if (options.Experience is not null && options.Experience.Any())
						enumVacancies = enumVacancies.Where(v => options.Experience!.Any(exp => exp == v.Experience));

					//FIlter by time
					if (options.PostedWithin is not null && options.PostedWithin.Any())
						enumVacancies = enumVacancies.Where(v => options.PostedWithin.Any(pw => pw != PostedWithinEnum.Any && v.CreatedTime > DateTime.Now.AddDays(-(int)pw)));

					//Filter by JobRegion
					if (options.JobRegion is not null && options.JobRegion != "Anywhere")
						enumVacancies = enumVacancies.Where(v => v.Region!.Contains(options.JobRegion));

					//FIlter by Tags
					if (options.Tags!.Count > 0)
						enumVacancies = enumVacancies.Where(v => v.Tags!.Any(vt => options.Tags!.Any(ot => ot.Contains(vt.Name!))));
				}
			var result = enumVacancies.ToList();
			return result;
		}
	}
}
