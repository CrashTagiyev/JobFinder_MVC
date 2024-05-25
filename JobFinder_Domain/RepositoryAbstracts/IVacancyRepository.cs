using JobFinder_Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.RepositoryAbstracts
{
	public interface IVacancyRepository:IRepository<Vacancy>
	{
		public Task<ICollection<Vacancy>> GetByCompanyNameAsync(string companyName);
	}
}
