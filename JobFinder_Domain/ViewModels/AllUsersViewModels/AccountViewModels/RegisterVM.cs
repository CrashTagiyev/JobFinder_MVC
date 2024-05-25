
using JobFinder_Domain.Users;

namespace JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels
{
    public class RegisterVM
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordConfirmed { get; set; }



        //Operator overloading
        public static implicit operator AppUser(RegisterVM registerVM)
        {
            return new AppUser()
            {
                Email = registerVM.Email,
                UserName = registerVM.UserName,
                Firstname = registerVM.Firstname,
                Lastname = registerVM.Lastname,
                PhoneNumber = registerVM.PhoneNumber,
            };
        }
    }
}
