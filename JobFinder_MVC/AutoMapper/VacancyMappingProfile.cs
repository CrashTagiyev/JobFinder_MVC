using AutoMapper;
using JobFinder_Application.Services;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;

namespace JobFinder_Presentation.AutoMapper
{
	public class VacancyMappingProfile : Profile
	{

		public VacancyMappingProfile()
		{
			CreateMap<VacancyVM, Vacancy>();
			CreateMap<CompanyVM, Company>();

		}


	}
}
