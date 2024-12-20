﻿using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configures the Sale entity for Entity Framework Core.
    /// </summary>
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        /// <summary>
        /// Configures the Sale entity properties and relationships.
        /// </summary>
        /// <param name="builder">The builder being used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(50);
            builder.Property(s => s.SaleDate).IsRequired();
            builder.Property(s => s.Customer).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Branch).IsRequired().HasMaxLength(100);
            builder.Property(s => s.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(s => s.IsCancelled).IsRequired();

            builder.HasMany(s => s.Items)
                   .WithOne()
                   .HasForeignKey(si => si.Id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
