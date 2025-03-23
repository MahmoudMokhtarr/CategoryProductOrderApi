using CategoryProductOrderApi.Dtos;
using FluentValidation;

namespace CategoryProductOrderApi.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {

            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(p => p.ProductName)
              .NotEmpty().WithMessage("Product name is required.")
              .MinimumLength(3).WithMessage("Product name must be at least 3 characters long.")
              .MaximumLength(150).WithMessage("Product name must not exceed 150 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(p => p.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");

            RuleFor(p => p.CategoryID)
                .GreaterThan(0).WithMessage("Category ID must be a valid positive number.");

        }

    }
}
