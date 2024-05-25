using JobFinder_Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;

namespace JobFinder_Domain.Users
{
	public class AppUser : IdentityUser
	{
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		
		//Navigation property
		public virtual List<Vacancy>? Vacancies { get; set; }
		
	}
}
