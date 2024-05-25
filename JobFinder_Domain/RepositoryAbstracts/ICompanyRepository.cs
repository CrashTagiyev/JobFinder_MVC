using JobFinder_Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.RepositoryAbstracts
{
	public interface ICompanyRepository:IRepository<Company>
	{
		public bool isCompanyExistByName(string companyName);
		public Task<Company> GetCompanyByNameAsync(string companyName);
	}
}
