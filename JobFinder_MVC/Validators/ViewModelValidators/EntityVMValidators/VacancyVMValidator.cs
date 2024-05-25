using FluentValidation;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;

namespace JobFinder_Presentation.Validators.ViewModelValidators.EntityVMValidators
{
	public class VacancyVMValidator : AbstractValidator<VacancyVM>
	{
		public VacancyVMValidator()
		{
			RuleFor(v => v.Title)
				.MinimumLength(3)
				.WithMessage("Title must be minimum 3  letter")
				.NotEmpty()
				.NotNull();


			RuleFor(v => v.JobNature)
				.IsInEnum()
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.MinimumSalary)
				.Must(MS => MS > 600)
				.LessThan(v=>v.MaximumSalary)
				.WithMessage("Minimum salary must be higher than 600")
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.MaximumSalary)
				.GreaterThan(v => v.MinimumSalary)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.MinimumAge)
				.LessThan(v => v.MaximumAge)
				.Must(a => a > 18)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.MaximumAge)
				.GreaterThan(v => v.MinimumAge)
				.Must(MA => MA < 60)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.Email)
				.EmailAddress()
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.PhoneNumber)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.ApplicationDate)
				.Must(AD => AD > DateTime.Now)
				.WithMessage("Application date must be the future date")
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.CategoryId)
				.NotEmpty()
				.NotNull();


			RuleFor(v => v.Company!.CompanyName)
				.MinimumLength(3)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.Company!.CompanyInformation)
				.MinimumLength(6)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.Company!.CompanyImageFile)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.Education)
				.IsInEnum()
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.Gender)
				.IsInEnum()
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.ContactPersonName)
				.MinimumLength(3)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.Experience)
				.IsInEnum()
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.Region)
				.MinimumLength(3)
				.NotEmpty()
				.NotNull();

			RuleFor(v => v.JobDescription)
				.MinimumLength(6)
				.NotEmpty()
				.NotNull();


		}
	}
}
