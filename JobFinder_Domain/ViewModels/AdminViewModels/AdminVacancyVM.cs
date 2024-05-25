using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.Enums;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.FindJobViewModels;
using JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.ViewModels.AdminViewModels
{
    public class AdminVacancyVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? JobDescription { get; set; }
        public ExperienceEnum? Experience { get; set; }
        public GenderEnum? Gender { get; set; } 
        public EducationDegreeEnum? Education { get; set; } 
        public JobNatureEnum? JobNature { get; set; } 
        public double MinimumSalary { get; set; } 
        public double MaximumSalary { get; set; }
        public short MinimumAge { get; set; } 
        public short MaximumAge { get; set; }
        public bool AcceptsDisabledApplicants { get; set; } = false;
        public bool AcceptsIncompleteCV { get; set; } = false;
        public string? Region { get; set; }
        public string? Address { get; set; }
        public string? ContactPersonName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual AdminCompanyVM Company { get; set; }
        public virtual AdminCategoryVM Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    
    }
}
