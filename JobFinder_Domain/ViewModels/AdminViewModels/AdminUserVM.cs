using JobFinder_Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.ViewModels.AdminViewModels
{
    public class AdminUserVM
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }


        public virtual List<Vacancy>? Vacancies { get; set; }
    }
}
