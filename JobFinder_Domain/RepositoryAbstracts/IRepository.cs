using JobFinder_Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.RepositoryAbstracts
{
	public interface IRepository<T> where T : Entity
	{
		public Task CreateAsync(T entity);
		public Task UpdateAsync(T entity);
		public Task DeleteAsync(T entity);
		public Task<T?> GetByIdAsync(int Id);
		public Task<IEnumerable<T>> GetAllAsync();
		public  Task SaveChangesAsync();

	}
}
