using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProductService.Application.DTOs;

namespace ProductService.Application.Validators
{
    public class CreatShoeDtoValidator : AbstractValidator<CreateShoeDto>
    {
        public CreatShoeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required.")
                .MaximumLength(50).WithMessage("Brand must not exceed 50 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.")
                .LessThanOrEqualTo(10000).WithMessage("Price must not exceed 10,000.");
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be zero or greater.")
                .LessThanOrEqualTo(1000).WithMessage("Quantity must not exceed 1,000.");
            RuleFor(x => x.Size)
                .InclusiveBetween(36, 50).WithMessage("Size must be between 36 and 50.");
            RuleFor(x => x.Color)
                .NotEmpty().WithMessage("Color is required.")
                .MaximumLength(30).WithMessage("Color must not exceed 30 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
