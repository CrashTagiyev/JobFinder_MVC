using JobFinder_Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.ViewModels.AdminViewModels
{
    public class AdminCompanyVM
    {
        public string? CompanyName { get; set; }
        public string? CompanyInformation { get; set; }
        public string? CompanyImageUrl { get; set; }

        //Navigation property
        public virtual ICollection<Vacancy>? vacancies { get; set; }
    }
}
