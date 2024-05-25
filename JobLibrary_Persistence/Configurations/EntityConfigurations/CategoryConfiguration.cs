using JobFinder_Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Persistence.Configurations.EntityConfigurations
{
	internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{

			builder.Property(c => c.Name)
				.HasMaxLength(20)
				.IsRequired();

		}
	}
}
