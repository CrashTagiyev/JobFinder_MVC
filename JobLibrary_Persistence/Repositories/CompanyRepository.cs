using Azure;
using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.RepositoryAbstracts;
using JobFinder_Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Persistence.Repositories
{
	public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
	{
		private readonly JobFinderDbContext _context;

		public CompanyRepository(JobFinderDbContext context)
		{
			_context = context;
		}

		public override async Task CreateAsync(Company company)
		{
			await _context.Companies.AddAsync(company);
			await SaveChangesAsync();
		}

		public override async Task DeleteAsync(Company company)
		{
			_context.Companies.Remove(company);
			await SaveChangesAsync();
		}

		public override async Task<IEnumerable<Company>> GetAllAsync()
		{
			return await _context.Companies.ToListAsync();
		}

		public override async Task<Company?> GetByIdAsync(int id)
		{
			return await _context.Companies.FindAsync(id);
		}

		public async Task<Company> GetCompanyByNameAsync(string companyName)
		{
			var company=await _context.Companies.FirstOrDefaultAsync(c=>c.CompanyName==companyName);
			return company!;
		}

		public bool isCompanyExistByName(string companyName)
		{
			var company = _context.Companies.FirstOrDefault(c => c.CompanyName == companyName);
			if (company is not null)
				return true;
			return false;
		}

		public override async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public override async Task UpdateAsync(Company company)
		{
			_context.Companies.Update(company);
			await SaveChangesAsync();
		}
	}
}
