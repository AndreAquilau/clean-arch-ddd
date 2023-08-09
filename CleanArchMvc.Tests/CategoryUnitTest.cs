using System;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Tests;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState() 
    { 
        Action action = () => new Category(1, "Category Name");

        action
            .Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Value Invalid Id")]
    public void CreateCategory_WithInvalidValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact(DisplayName = "Create Category With Short Name Value")]
    public void CreateCategory_ShortNameValue_DomainExceptionValidationShort()
    {
        Action action = () => new Category(1, "Te");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 charecters.");
    }

    [Fact(DisplayName = "Create Category Missing Name Value")]
    public void CreateCategory_MissingNameValue_DomainExceptionValidationRequiredName()
    {
        Action action = () => new Category(1, "");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Name. Name is required.");
    }

    [Fact(DisplayName = "Create Category Null Name Value")]
    public void CreateCategory_NullNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Name. Name is required.");
    }

}
