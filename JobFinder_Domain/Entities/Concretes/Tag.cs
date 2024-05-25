using JobFinder_Domain.Entities.Abstracts;


namespace JobFinder_Domain.Entities.Concretes
{
	public class Tag : Entity
	{
		public string? Name { get; set; }

		//navigation properties
		public virtual ICollection<Vacancy>? Vacancies { get; set; }
	}
}
