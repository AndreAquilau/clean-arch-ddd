using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Tests;

public class ProductUnitTest
{
    [Fact(DisplayName = "Create Product With Valid State")]
    public void CreateProduct_WithParametersValid_ObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Description Product", 10.00M, 10, null);


        action
            .Should()
            .NotThrow<DomainExceptionValidation>();

    }

    [Fact(DisplayName = "Create Product With Value Invalid Id")]
    public void CreateProduct_WithInvalidValue_DomainExceptionValidationId()
    {
        Action action = () => new Product(-1, "Product Name", "Description Product", 10.00M, 10, null);

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Id invalid value.");
    }

    [Fact(DisplayName = "Create Product With Empty Name Value")]
    public void CreateProduct_EmptyNameValue_DomainExceptionValidationRequiredName()
    {
        Action action = () => new Product(1, "", "Description Product", 10.00M, 10, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Product With Missing Value Name")]
    public void CreateProduct_MissingNameValue_DomainExceptionValidationRequired()
    {
        Action action = () => new Product(1, null, "Description Product", 10.00M, 10, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required.");
    }

    [Fact(DisplayName = "Create Product Short Name Value")]
    public void CreateProduct_ShortNameValue_DomainExceptionValidationShort()
    {
        Action action = () => new Product(1, "Pr", "Description Product", 10.00M, 10, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters.");
    }

    [Fact(DisplayName = "Create Product Missing Description Value")]
    public void CreateProduct_MissingDescriptionValue_DomainExceptionValidationRequiredDescription()
    {
        Action action = () => new Product(1, "Product Name", null, 10.00M, 10, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required.");
    }

    [Fact(DisplayName = "Create Product Empty Description Value")]
    public void CreateProduct_EmptyDescriptionValue_DomainExceptionValidationRequiredDescription()
    {
        Action action = () => new Product(1, "Product Name", "", 10.00M, 10, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required.");
    }

    [Fact(DisplayName = "Create Product Short Description Value")]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionValidationShortDescription()
    {
        Action action = () => new Product(1, "Product Name", "Desc", 10.00M, 10, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description, too short, minimum 5 characters.");
    }

    [Fact(DisplayName = "Create Product With Price Value Invalid")]
    public void CreateProduct_WithPriceValueInvalid_DomainExceptionValidateInvalidPriceValue()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", -100.00M, 10, null);

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value.");
    }

    [Fact(DisplayName = "Create Product With Stock Value Invalid")]
    public void CreateProduct_WithStockValueInvalid_DomainExceptionValidationStockValueInvalid()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 100.00M, -100, null);

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value.");
    }

    [Fact(DisplayName = "Create Product With Invalid Image Character Count")]
    public void CreateProduct_WithInvalidInvalidImageCharacterCount_DomainExceptionValidationInvalidCharacterCount()
    {
        Action action = () => new Product(1, "Product Name", "Description Name", 10.00M, 10, "A".PadRight(260, 'A'));

        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters.");
    }

}

