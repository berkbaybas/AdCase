using AdCase.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Infrastructre.EntityConfigurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams").HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Country).HasColumnName("Country");
            builder.Property(t => t.GroupId).HasColumnName("GroupId");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(t => t.LastModifiedDate).HasColumnName("UpdatedDate");
            builder.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
