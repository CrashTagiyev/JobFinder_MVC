using AutoMapper;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.Users;
using JobFinder_Domain.ViewModels.AdminViewModels;

namespace JobFinder_Presentation.AutoMapper.AdminsVMMappingProfile
{
	public class AdminMappingProfile : Profile
	{
		public AdminMappingProfile()
		{
			//Admin View models Mapping
			CreateMap<AppUser, AdminUserVM>();
			CreateMap<Vacancy, AdminVacancyVM>();
			CreateMap<Company, AdminCompanyVM>();
			CreateMap<Category, AdminCategoryVM>();
			CreateMap<AdminCategoryVM, AdminUpdateCategoryVM>();
			CreateMap<Category, AdminUpdateCategoryVM>();
			CreateMap<Tag, AdminTagVM>();
			CreateMap<Tag, AdminCreateTagVM>();
			CreateMap<Tag, AdminUpdateTagVM>();


			//reverse
			CreateMap<AdminUpdateCategoryVM, Category>();
			CreateMap<AdminCategoryVM, Category>();
			CreateMap<AdminCreateCategoryVM, Category>();
			CreateMap<AdminTagVM, Tag>();
			CreateMap<AdminUserVM, AppUser>();
			CreateMap<AdminVacancyVM, Vacancy>();
			CreateMap<AdminCompanyVM, Company>();
			CreateMap<AdminUpdateCategoryVM, AdminCategoryVM>();
			CreateMap<AdminCreateTagVM, Tag>();
			CreateMap<AdminUpdateTagVM, Tag>();
		}
	}
}
