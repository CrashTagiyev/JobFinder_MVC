using JobFinder_Domain.Entities.Abstracts;
using JobFinder_Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.RepositoryAbstracts
{
	public interface ICategoryRepository:IRepository<Category>
	{
	}
}
