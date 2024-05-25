using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Persistence.Repositories
{
	public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
	{
		private readonly JobFinderDbContext _context;

		public CategoryRepository(JobFinderDbContext context)
		{
			_context = context;
		}

		public override async Task CreateAsync(Category category)
		{
			await _context.Categories.AddAsync(category);
			await SaveChangesAsync();
		}

		public override async Task DeleteAsync(Category category)
		{
			_context.Categories.Remove(category);
			await SaveChangesAsync();
		}

		public override async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _context.Categories.ToListAsync();
		}


		public override async Task<Category?> GetByIdAsync(int id)
		{
			return await _context.Categories.FindAsync(id);
		}

		public override async Task UpdateAsync(Category category)
		{
			_context.Categories.Update(category);
			await SaveChangesAsync();
		}

		public override async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
