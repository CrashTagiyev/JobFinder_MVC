using JobFinder_Domain.Entities.Abstracts;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Persistence.Data;
using JobFinder_Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Persistence.Repositories
{
	public class VacancyRepository : GenericRepository<Vacancy>, IVacancyRepository
	{
		private readonly JobFinderDbContext _context;

		public VacancyRepository(JobFinderDbContext context)
		{
			_context = context;
		}

		public override async Task CreateAsync(Vacancy vacancy)
		{
			await _context.Vacancies.AddAsync(vacancy);
			await SaveChangesAsync();
		}

		public override async Task DeleteAsync(Vacancy vacancy)
		{
			_context.Vacancies.Remove(vacancy);
			await SaveChangesAsync();
		}

		public override async Task<IEnumerable<Vacancy>> GetAllAsync()
		{
			return await _context.Vacancies.ToListAsync();
		}

		public async Task<ICollection<Vacancy>> GetByCompanyNameAsync(string companyName)
		{
			return await _context.Vacancies.Where(v => v.Company.CompanyName!.ToLower().Contains(companyName.ToLower())).ToListAsync();
		}

		public override async Task<Vacancy?> GetByIdAsync(int id)
		{
			return await _context.Vacancies.FindAsync(id);
		}

		public override async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public override async Task UpdateAsync(Vacancy vacancy)
		{
			_context.Vacancies.Update(vacancy);
		}
	}
}
