using JobFinder_Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Persistence.Configurations.EntityConfigurations
{
	public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			

			//Property config
			builder.Property(u => u.UserName)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(u => u.Firstname)
				.HasMaxLength(18)
				.IsRequired();

			builder.Property(u => u.Lastname)
				.HasMaxLength(25)
				.IsRequired();

			builder.Property(u => u.PasswordHash)
				.IsRequired();

			builder.Property(u => u.Email)
				.IsRequired();

			builder.Property(u => u.PhoneNumber)
				.IsRequired();

		}
	}
}
