using FluentValidation;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDTO>
    {
        public ProductDtoValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("{PropetyName} is required").NotEmpty().WithMessage("{PropetyName} is required");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyNmae} must br greater 0");
            RuleFor(x => x.Stok).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyNmae} must br greater 0");
            RuleFor(x => x.CategoryId ).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyNmae} must br greater 0");

        }
    }
}
