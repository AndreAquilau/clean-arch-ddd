﻿using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(256).IsRequired();

        builder.Property(p => p.Description).HasMaxLength(5000).IsRequired();

        builder.Property(p => p.Price).HasPrecision(10,2).IsRequired();

        builder.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
    }
}

