using AutoMapper;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Domain.Users;
using JobFinder_Domain.ViewModels.AdminViewModels;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Application.Services.AdminServices
{
	public class AdminService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly ITagRepository _tagRepository;
		private readonly IVacancyRepository _vacancyRepository;
		private readonly ICompanyRepository _companyRepository;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public AdminService(ICategoryRepository categoryRepository, ITagRepository tagRepository, IVacancyRepository vacancyRepository, UserManager<AppUser> userManager, ICompanyRepository companyRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_tagRepository = tagRepository;
			_vacancyRepository = vacancyRepository;
			_userManager = userManager;
			_companyRepository = companyRepository;
			_mapper = mapper;
		}

		// Category CRUD operations
		public async Task<IEnumerable<AdminCategoryVM>> GetAllCategoriesAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();
			var categoryVMs = new List<AdminCategoryVM>();
			foreach (var category in categories)
			{
				var mappedCategory = _mapper.Map<AdminCategoryVM>(category);
				categoryVMs.Add(mappedCategory);
			}
			return categoryVMs;
		}

		public async Task<AdminCategoryVM> GetCategoryByIdAsync(int id)
		{
			var category =await _categoryRepository.GetByIdAsync(id);
			if (category is not null)
			{
				var categoryVM = _mapper.Map<AdminCategoryVM>(category);
				return categoryVM;
			}

			return null!;
		}

		public async Task AddCategoryAsync(AdminCreateCategoryVM categoryVM)
		{
			var category = _mapper.Map<Category>(categoryVM);
			await _categoryRepository.CreateAsync(category);
		}

		public async Task UpdateCategoryAsync(AdminUpdateCategoryVM categoryVM)
		{
			var updatedCategory =  _mapper.Map<Category>(categoryVM);

			if (updatedCategory is not null)
			{
				await _categoryRepository.UpdateAsync(updatedCategory);
				await _categoryRepository.SaveChangesAsync();
			}
		}

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);
			if (category != null)
			{
				await _categoryRepository.DeleteAsync(category);
			}
		}

		// Company CRUD operations
		public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
		{
			return await _companyRepository.GetAllAsync();
		}

		public async Task<Company> GetCompanyByIdAsync(int id)
		{
			return await _companyRepository.GetByIdAsync(id);
		}

		public async Task AddCompanyAsync(Company company)
		{
			await _companyRepository.CreateAsync(company);
		}

		public async Task UpdateCompanyAsync(Company company)
		{
			await _companyRepository.UpdateAsync(company);
		}

		public async Task DeleteCompanyAsync(int id)
		{
			var company = await _companyRepository.GetByIdAsync(id);
			if (company != null)
			{
				await _companyRepository.DeleteAsync(company);
			}
		}

		public async Task<Company> GetCompanyByNameAsync(string companyName)
		{
			return await _companyRepository.GetCompanyByNameAsync(companyName);
		}

		public bool IsCompanyExistByName(string companyName)
		{
			return _companyRepository.isCompanyExistByName(companyName);
		}

		// Tag CRUD operations
		public async Task<IEnumerable<AdminTagVM>> GetAllTagsAsync()
		{
			var tags = await _tagRepository.GetAllAsync();
			var tagVMs = new List<AdminTagVM>();
			foreach (var tag in tags)
			{
				var mappedTag = _mapper.Map<AdminTagVM>(tag);
				tagVMs.Add(mappedTag);
			}
			return tagVMs;
		}

		public async Task<AdminTagVM> GetTagByIdAsync(int id)
		{
			var tag= await _tagRepository.GetByIdAsync(id);
			var tagVM = _mapper.Map<AdminTagVM>(tag);
			return tagVM;
		}

		public async Task AddTagAsync(AdminCreateTagVM tagVM)
		{
			var tag = _mapper.Map<Tag>(tagVM);
			await _tagRepository.CreateAsync(tag);
		}

		public async Task UpdateTagAsync(AdminUpdateTagVM tagVM)
		{
			var updatedTag = _mapper.Map<Tag>(tagVM);

			if (updatedTag is not null)
			{
				await _tagRepository.UpdateAsync(updatedTag);
				await _tagRepository.SaveChangesAsync();
			}
		}

		public async Task DeleteTagAsync(int id)
		{
			var tag = await _tagRepository.GetByIdAsync(id);
			if (tag != null)
			{
				await _tagRepository.DeleteAsync(tag);
			}
		}

		// Vacancy CRUD operations
		public async Task<IEnumerable<AdminVacancyVM>> GetAllVacanciesAsync()
		{
			var vacancies = await _vacancyRepository.GetAllAsync();
			var vacancyVMs = new List<AdminVacancyVM>();
			foreach (var vacancy in vacancies)
			{
				var mapopedVacancy = _mapper.Map<AdminVacancyVM>(vacancy);
				vacancyVMs.Add(mapopedVacancy);
			}
			return vacancyVMs;
		}

		public async Task<AdminVacancyVM> GetVacancyByIdAsync(int id)
		{
			var vacancy = await _vacancyRepository.GetByIdAsync(id);

			if (vacancy is not null)
				return _mapper.Map<AdminVacancyVM>(vacancy);

			return null!;
		}

		public async Task AddVacancyAsync(Vacancy vacancy)
		{
			await _vacancyRepository.CreateAsync(vacancy);
		}

		public async Task UpdateVacancyAsync(AdminVacancyVM vacancyVM)
		{
			var vacancy = _mapper.Map<Vacancy>(vacancyVM);

			if (vacancy is not null)
			{
				await _vacancyRepository.UpdateAsync(vacancy);
				await _vacancyRepository.SaveChangesAsync();
			}
		}

		public async Task<bool> DeleteVacancyAsync(int id)
		{
			var vacancy = await _vacancyRepository.GetByIdAsync(id);
			if (vacancy is not null)
			{
				await _vacancyRepository.DeleteAsync(vacancy);
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<Vacancy>> GetVacanciesByCompanyNameAsync(string companyName)
		{
			return await _vacancyRepository.GetByCompanyNameAsync(companyName);
		}
	}
}
