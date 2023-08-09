using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : Entity
{
    public string? Name { get; private set; } = string.Empty;
    public ICollection<Product>? Products { get; private set; }

    public Category(string? name)
    {
        ValidateDomain(name);
        Products = new List<Product>().AsReadOnly();
        DomainExceptionValidation.When(Products == null, "Products Array not initialized.");
    }

    public Category(int id, string? name)
    {
        ValidateDomain(name);
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        Products = new List<Product>().AsReadOnly();
        DomainExceptionValidation.When(Products == null, "Products Array not initialized.");
    }

    private void ValidateDomain(string? name)
    {
        DomainExceptionValidation.When(
            string.IsNullOrEmpty(name),
            "Invalid Name. Name is required."
        );

        DomainExceptionValidation.When(
            name?.Length < 3,
            "Invalid name, too short, minimum 3 charecters."
        );

        Name = name;
    }

    public void Update(string? name)
    {
        ValidateDomain(name);
    }
}
