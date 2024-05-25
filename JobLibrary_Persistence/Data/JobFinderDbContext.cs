using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.Users;
using JobFinder_Persistence.Configurations.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace JobFinder_Persistence.Data
{
	public class JobFinderDbContext : IdentityDbContext<AppUser>
	{
		public JobFinderDbContext(DbContextOptions<JobFinderDbContext> option)
			: base(option)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies(true);
		}


		protected override void OnModelCreating(ModelBuilder builder)
		{

			builder.ApplyConfiguration(new AppUserConfiguration());
			builder.ApplyConfiguration(new VacancyConfiguration());
			builder.ApplyConfiguration(new TagConfiguration());
			builder.ApplyConfiguration(new CategoryConfiguration());
			base.OnModelCreating(builder);
		}

		public DbSet<Vacancy> Vacancies { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Tag> Tags { get; set; }
	}
}
