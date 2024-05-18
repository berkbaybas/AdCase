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
    public class DrawConfiguration : IEntityTypeConfiguration<Draw>
    {
        public void Configure(EntityTypeBuilder<Draw> builder)
        {
            builder.ToTable("Draws").HasKey(d => d.Id);

            builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
            builder.Property(d => d.DrawnBy).HasColumnName("DrawnBy");
            builder.Property(d => d.TeamId).HasColumnName("TeamId");
            builder.Property(d => d.GroupId).HasColumnName("GroupId");
            builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(d => d.LastModifiedDate).HasColumnName("UpdatedDate");
            builder.Property(t => t.LastModifiedBy).HasColumnName("LastModifiedBy");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        }
    }
}
