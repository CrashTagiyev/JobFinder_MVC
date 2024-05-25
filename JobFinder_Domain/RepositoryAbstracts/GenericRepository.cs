using JobFinder_Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.RepositoryAbstracts
{
	public abstract class GenericRepository<T> : IRepository<T> where T : Entity, new()
	{
		public abstract Task CreateAsync(T entity);
		public abstract Task DeleteAsync(T entity);
		public abstract Task<IEnumerable<T>> GetAllAsync();
		public abstract Task<T?> GetByIdAsync(int Id);
		public abstract Task SaveChangesAsync();
		public abstract Task UpdateAsync(T entity);

	}
}
