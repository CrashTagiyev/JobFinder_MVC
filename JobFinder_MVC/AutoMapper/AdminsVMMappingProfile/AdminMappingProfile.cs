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
            CreateMap<Category, AdminCategoryVM>();
            CreateMap<Tag, AdminTagVM>();
            CreateMap<AppUser, AdminUserVM>();
            CreateMap<Vacancy, AdminVacancyVM>();
            CreateMap<Company, AdminCompanyVM>();

            //reverse
			CreateMap<AdminCategoryVM, Category>();
			CreateMap<AdminCreateCategoryVM, Category>();
			CreateMap<AdminTagVM, Tag>();
			CreateMap<AdminUserVM, AppUser>();
			CreateMap<AdminVacancyVM, Vacancy>();
			CreateMap<AdminCompanyVM, Company>();
		}
    }
}
