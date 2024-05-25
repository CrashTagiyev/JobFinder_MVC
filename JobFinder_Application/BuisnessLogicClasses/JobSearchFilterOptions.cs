using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Application.BuisnessLogicClasses
{
	public class JobSearchFilterOptions
	{
		public string? SearchedWord { get; set; } = null;
		public string? CategoryName { get; set; } = null;
		public List<string>? Tags { get; set; } = new();
		public List<JobNatureEnum>? JobType { get; set; } = null;
		public List<ExperienceEnum>? Experience { get; set; } = null;
		public List<PostedWithinEnum>? PostedWithin { get; set; } = null;
		public string? JobRegion { get; set; } = null;



		public bool IsOptionsNullOrEmpty()
		{
			return SearchedWord != null ||
				   CategoryName != null ||
				   (Tags != null && Tags.Count > 0) ||
				   (JobType != null && JobType.Count > 0) ||
				   (Experience != null && Experience.Count > 0) ||
				   (PostedWithin != null && PostedWithin.Count > 0) ||
				   JobRegion != null;
		}

	}
}
