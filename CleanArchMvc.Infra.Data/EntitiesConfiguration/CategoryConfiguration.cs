using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(256).IsRequired();

        List<Category> defaultValues = new List<Category>();

        defaultValues.Add(new Category(1, "Material Escolar"));
        defaultValues.Add(new Category(2, "Eletrônicos"));
        defaultValues.Add(new Category(3, "Acessórios"));

        builder.HasData(defaultValues);

    }
}

