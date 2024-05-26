using AutoMapper;
using JobFinder_Application.BuisnessLogicClasses;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;
using Microsoft.AspNetCore.Http;
using System.Web.Mvc;
namespace JobFinder_Application.Services
{
	public class VacancyServices
	{

		private readonly IVacancyRepository _vacancyRepository;
		private readonly ITagRepository _tagRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;

		public VacancyServices(IVacancyRepository vacancyRepository, ITagRepository tagRepository, ICategoryRepository categoryRepository, ICompanyRepository companyRepository, IMapper mapper)
		{
			_vacancyRepository = vacancyRepository;
			_tagRepository = tagRepository;
			_categoryRepository = categoryRepository;
			_companyRepository = companyRepository;
			_mapper = mapper;
		}

		public async Task CreateVacancyAsync(Vacancy vacancy, int categoryId, List<int> tagIds)
		{

			var category = await _categoryRepository.GetByIdAsync(categoryId);
			if (category != null)
				vacancy.Category = category;

			vacancy.Tags = new List<Tag>();
			if (tagIds != null)
				foreach (int tagId in tagIds)
				{
					var tag = await _tagRepository.GetByIdAsync(tagId);
					if (tag != null)
						vacancy.Tags.Add(tag);
				}

			if (!_companyRepository.isCompanyExistByName(vacancy.Company.CompanyName!))
				await _companyRepository.CreateAsync(vacancy.Company);
			else
			{
				var company = await _companyRepository.GetCompanyByNameAsync(vacancy.Company.CompanyName!);
				if (company != null)
					vacancy.Company = company;
			}
			vacancy.CreatedTime = DateTime.UtcNow;
			await _vacancyRepository.CreateAsync(vacancy);
		}
		public async Task<string> SaveImageToFolderAsync(string uploadFolderPath, IFormFile imageFile)
		{
			if (imageFile == null || imageFile.Length == 0)
				throw new ArgumentException("Invalid image file.");

			var allowedImageTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/bmp" };
			if (!allowedImageTypes.Contains(imageFile.ContentType.ToLower()))
				throw new ArgumentException("Invalid image file type.");

			string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
			string filePath = Path.Combine(uploadFolderPath, uniqueFileName);

			if (!Directory.Exists(uploadFolderPath))
			{
				Directory.CreateDirectory(uploadFolderPath);
			}

			// Save the file
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await imageFile.CopyToAsync(fileStream);
			}

			return uniqueFileName;
		}


		public async Task<Vacancy> MakeNewVacancyAsync(string companyLogoFolderPath, VacancyVM vacancyVM)
		{
			string companyLogoUrl = await SaveImageToFolderAsync(companyLogoFolderPath, vacancyVM.Company!.CompanyImageFile!);
			var newVacancy = _mapper.Map<Vacancy>(vacancyVM);


			var company = _mapper.Map<Company>(vacancyVM.Company);
			if (company is not null)
			{
				newVacancy.Company = company;
				newVacancy.Company.CompanyImageUrl = "/CompanyLogoImages/" + companyLogoUrl;
			}

			return newVacancy;
		}
		public async Task<List<SelectListItem>> GetTagsSelectListItemsAsync()
		{
			var tags = await _tagRepository.GetAllAsync();
			var selectItemsTags = new List<SelectListItem>();

			if (tags != null && tags.Any())
				foreach (Tag tag in tags)
					selectItemsTags.Add(new SelectListItem { Value = tag.Id.ToString(), Text = tag.Name });

			return selectItemsTags;
		}
		public async Task<List<SelectListItem>> GetCategorySelectListItemsAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();
			var selectItemsCategories = new List<SelectListItem>();


			if (categories != null && categories.Any())
			{
				foreach (Category cat in categories)
					selectItemsCategories.Add(new SelectListItem { Value = cat.Id.ToString(), Text = cat.Name });
				selectItemsCategories[0].Selected = true;
			}

			return selectItemsCategories;
		}

		//Lists-------------
		public async Task<List<Tag>> GetTagsAsync()
		{
			var tags = await _tagRepository.GetAllAsync();
			return tags.ToList();
		}
		public async Task<List<Category>> GetCategories()
		{
			var categories = await _categoryRepository.GetAllAsync();
			return categories.ToList();
		}
		public async Task<List<Vacancy>> GetVacancies()
		{
			var vacancies = await _vacancyRepository.GetAllAsync();
			return vacancies.ToList();
		}
	}
}
