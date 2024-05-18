using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdCase.Domain.Entities;

namespace AdCase.Infrastructre.EntityConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups").HasKey(g => g.Id);

            builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
            builder.Property(g => g.GroupName).HasColumnName("Name");
            builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(g => g.LastModifiedDate).HasColumnName("UpdatedDate");
            builder.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
