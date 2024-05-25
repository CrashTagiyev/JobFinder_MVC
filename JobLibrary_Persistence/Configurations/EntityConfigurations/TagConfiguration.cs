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
	internal class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{

			builder.Property(t => t.Name)
				.HasMaxLength(50)
				.IsRequired();
		}
	}
}
