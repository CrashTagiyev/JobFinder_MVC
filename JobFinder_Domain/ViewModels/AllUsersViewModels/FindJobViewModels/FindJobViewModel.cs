
using JobFinder_Domain.Enums;

namespace JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.FindJobViewModels
{
	public class FindJobViewModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public FindJobCompanyVM? CompanyVM { get; set; }
		public string? Region { get; set; }
		public string? MinimumSalary { get; set; }
		public string? MaximumSalary { get; set; }
		public JobNatureEnum JobNature { get; set; }
		public DateTime CreatedTime { get; set; }


		public async Task<string> GetPostedTimeAgoString()
		{

			var timeDifference = DateTime.UtcNow - CreatedTime;
			if (timeDifference.TotalDays >= 1)
				return await Task.FromResult($"{(int)timeDifference.TotalDays} days ago");
			else if (timeDifference.TotalHours >= 1)
				return await Task.FromResult($"{(int)timeDifference.TotalHours} hours ago");
			else if (timeDifference.TotalMinutes >= 1)
				return await Task.FromResult($"{(int)timeDifference.TotalMinutes} minutes ago");
			else
				return await Task.FromResult($"{(int)timeDifference.TotalSeconds} seconds ago");
		}
	}
}
