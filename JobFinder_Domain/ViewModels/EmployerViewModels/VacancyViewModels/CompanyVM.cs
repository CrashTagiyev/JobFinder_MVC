using Microsoft.AspNetCore.Http;

namespace JobFinder_Presentation.Areas.Employer.Models.VacancyViewModels
{
	public class CompanyVM
	{
		public string? CompanyName { get; set; }
		public string? CompanyInformation { get; set; }
		public IFormFile? CompanyImageFile { get; set; }
	}
}
