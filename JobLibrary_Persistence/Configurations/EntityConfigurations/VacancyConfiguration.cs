using JobFinder_Domain.Entities.Concretes;
using JobFinder_Domain.Enums;
using JobFinder_Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace JobFinder_Persistence.Configurations.EntityConfigurations
{
	internal class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
	{
		public void Configure(EntityTypeBuilder<Vacancy> builder)
		{

			//Column constraints

			builder.Property(v => v.Title)
				.IsRequired()
				.HasMaxLength(60);

			builder.Property(V => V.CategoryId)
				.IsRequired();

			builder.Property(V => V.JobNature)
				.HasDefaultValue(JobNatureEnum.FullTime);

			builder.Property(V => V.MinimumSalary)
				.IsRequired();
				
			builder.Property(V => V.MaximumSalary)
				.IsRequired();

			builder.Property(V => V.MinimumAge)
				.HasDefaultValue(18);

			builder.Property(V => V.MaximumAge)
				.HasDefaultValue(60);

			builder.Property(V => V.AcceptsDisabledApplicants)
				.HasDefaultValue(false);

			builder.Property(V => V.AcceptsIncompleteCV)
				.HasDefaultValue(false);

			builder.Property(V => V.Address)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(V => V.PhoneNumber)
				.IsRequired();

			builder.Property(V => V.ApplicationDate)
				.IsRequired();

			builder.Property(V => V.ContactPersonName)
				.IsRequired();

			builder.Property(V => V.Education)
				.IsRequired();

			builder.Property(V => V.Email)
				.IsRequired();

			builder.Property(V => V.Experience)
				.IsRequired();

			builder.Property(V => V.Gender)
				.IsRequired();

			builder.Property(V => V.Region)
				.IsRequired();

		}
	}
}
