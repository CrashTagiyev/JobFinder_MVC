using FluentValidation;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;

namespace JobFinder_Presentation.Validators.ViewModelValidators.EntityVMValidators
{
	public class CompanyValidator : AbstractValidator<CompanyVM>
	{
		public CompanyValidator()
		{
			RuleFor(c => c.CompanyName)
				.NotEmpty()
				.MaximumLength(30);

			RuleFor(c => c.CompanyInformation)
				.NotEmpty()
				.NotNull();

			RuleFor(c => c.CompanyImageFile)
				.NotNull()
				.NotEmpty();
		}
	}
}
