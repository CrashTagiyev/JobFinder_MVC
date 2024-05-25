using JobFinder_Domain.Entities.Abstracts;


namespace JobFinder_Domain.Entities.Concretes
{
	public class Category : Entity
	{
		public string? Name { get; set; }

		//Navigation properties
		public virtual ICollection<Vacancy>? Vacancies { get; set; }

	}
}
