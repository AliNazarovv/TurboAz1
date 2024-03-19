using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAzORM.Models.Entities;

namespace TurboAzORM.Models.Configurations
{
    public class AnnouncementEntityTypeConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Price).HasColumnType("decimal(18,2)");
            builder.Property(m => m.March).HasColumnType("decimal(18,2)");
            builder.Property(m => m.ModelId).HasColumnType("int");
            builder.Property(m => m.Category).HasColumnType("int").HasMaxLength(100).IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.DeletedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");
            builder.Property(m => m.Year).HasColumnType("int");
            builder.Property(m => m.Transmissions).HasColumnType("int").IsRequired();
            builder.Property(m => m.FuelType).HasColumnType("int").IsRequired();
            builder.Property(m => m.Gear).HasColumnType("int").IsRequired();
            builder.HasKey(m=>m.Id);
            builder.ToTable("Announcements");




        }
    }
}
