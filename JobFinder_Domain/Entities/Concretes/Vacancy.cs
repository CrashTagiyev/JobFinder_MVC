using JobFinder_Domain.Entities.Abstracts;
using JobFinder_Domain.Enums;
using JobFinder_Domain.Users;


namespace JobFinder_Domain.Entities.Concretes
{
	public class Vacancy : Entity
	{
		public string? Title { get; set; }
		public string? JobDescription { get; set; }
		public ExperienceEnum? Experience { get; set; } = ExperienceEnum.Junior;
		public GenderEnum? Gender { get; set; } = GenderEnum.Male;
		public EducationDegreeEnum? Education { get; set; } = EducationDegreeEnum.HighSchoolDiploma;
		public JobNatureEnum? JobNature { get; set; } = JobNatureEnum.FullTime;
		public double MinimumSalary { get; set; } = 600;
		public double MaximumSalary { get; set; }
		public short MinimumAge { get; set; } = 18;
		public short MaximumAge { get; set; } = 60;
		public bool AcceptsDisabledApplicants { get; set; } = false;
		public bool AcceptsIncompleteCV { get; set; } = false;
		public string? Region { get; set; }
		public string? Address { get; set; }
		public string? ContactPersonName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public DateTime? ApplicationDate { get; set; }




		//Foreign keys
		public string? UserId { get; set; }
		public int CategoryId { get; set; }
		public int CompanyId { get; set; }

		//Navigation properties
		public virtual Company Company { get; set; }
		public virtual Category Category { get; set; }
		public virtual AppUser User { get; set; }
		public virtual ICollection<Tag>? Tags { get; set; }

	}
}
