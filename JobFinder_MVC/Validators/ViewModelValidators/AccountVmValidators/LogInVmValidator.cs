using FluentValidation;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels;

namespace JobFinder_Presentation.Validators.ViewModelValidators.AccountVmValidators
{
    public class LogInVmValidator : AbstractValidator<LogInVM>
    {
        public LogInVmValidator()
        {
            RuleFor(l => l.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(l => l.Password)
                .NotEmpty();
        }
    }
}
