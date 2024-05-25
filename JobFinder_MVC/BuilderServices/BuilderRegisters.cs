using FluentValidation.AspNetCore;
using FluentValidation;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Persistence.Data;
using JobFinder_Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels;
using JobFinder_Application.Services;
using JobFinder_Presentation.AutoMapper.AccountMappingProfiles;
using JobFinder_Domain.Users;
using JobFinder_Presentation.IdentityConfig;
using Microsoft.AspNetCore.Identity;
using JobFinder_Presentation.AutoMapper;
using JobFinder_Presentation.AutoMapper.JobFinderMappingProfile;
using JobFinder_Application.Services.AdminServices;

namespace JobFinder_Presentation.BuilderServices
{
	public static class BuilderRegisters
	{

		//Repositories
		public static void RepositoryRegister(this IServiceCollection services)
		{
			services.AddScoped<IVacancyRepository, VacancyRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ITagRepository, TagRepository>();
			services.AddScoped<ICompanyRepository, CompanyRepository>();

		}

		//DbContext
		public static void DbContextRegister(this WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<JobFinderDbContext>(option =>
			option.UseSqlServer(builder.Configuration.GetConnectionString("Default"), sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

		}

		//Fluent Validators
		public static void FluentValidatorRegister(this IServiceCollection services)
		{
			services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<Program>();

		}
		public static void ViewModelsRegister(this IServiceCollection services)
		{
			services.AddScoped<RegisterVM>();
			services.AddScoped<LogInVM>();
		}

		public static void AppServicesRegister(this IServiceCollection services)
		{
			services.AddScoped<VacancyServices>();
			services.AddScoped<JobFinderServices>();
			services.AddScoped<AdminService>();
		}

		public static void AutoMapperRegister(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Program));
			services.AddAutoMapper(typeof(JobFinderMappingProfile));	
			services.AddAutoMapper(typeof(VacancyMappingProfile));
		}

		public static void IdentityRegister(this IServiceCollection services)
		{
			//Identity options
			services.AddIdentity<AppUser, IdentityRole>(MyIdentityConfig.ConfigureIdentityOptions).AddEntityFrameworkStores<JobFinderDbContext>().AddDefaultTokenProviders();
			//Cookie options
			services.ConfigureApplicationCookie(MyIdentityConfig.ConfigureIdentityCookie);

		}
	}
}
