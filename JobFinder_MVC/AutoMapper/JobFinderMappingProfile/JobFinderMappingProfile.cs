using AutoMapper;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.FindJobViewModels;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.JobDetailViewModels;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;

namespace JobFinder_Presentation.AutoMapper.JobFinderMappingProfile
{
	public class JobFinderMappingProfile : Profile
	{
		public JobFinderMappingProfile()
		{
			//Find job
			CreateMap<Vacancy, FindJobViewModel>();
			CreateMap<Company, FindJobCompanyVM>();


			//Job Detail
			CreateMap<Vacancy, JobDetailVM>();
		}
	}
}
