using FluentValidation;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels;

namespace JobFinder_Presentation.Validators.ViewModelValidators.AccountVmValidators
{
    public class RegistrationVmValidator : AbstractValidator<RegisterVM>
    {
        public RegistrationVmValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(u => u.UserName)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(u => u.PasswordHash)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(u => u.PasswordConfirmed)
                .NotEmpty()
                .Equal(u => u.PasswordHash)
                .WithMessage("Confirm password and password must be same")
                .MinimumLength(6);

            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(u => u.Firstname)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(18);

            RuleFor(u => u.Lastname)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(25);
        }
    }
}
