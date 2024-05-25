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
	public class TagRepository:GenericRepository<Tag>,ITagRepository
	{
		private readonly JobFinderDbContext _context;

		public TagRepository(JobFinderDbContext context)
		{
			_context = context;
		}

		public override async Task CreateAsync(Tag tag)
		{
			await _context.Tags.AddAsync(tag);
			await SaveChangesAsync();
		}

		public override async Task DeleteAsync(Tag tag)
		{
			_context.Tags.Remove(tag);
			await SaveChangesAsync();
		}

		public override async Task<IEnumerable<Tag>> GetAllAsync()
		{
			return await _context.Tags.ToListAsync();
		}


		public override async Task<Tag?> GetByIdAsync(int id)
		{
			return await _context.Tags.FindAsync(id);
		}

		public override async Task UpdateAsync(Tag tag)
		{
			_context.Tags.Update(tag);
			await SaveChangesAsync();
		}

		public override async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
