using CategoryProductOrderApi.Dtos;
using FluentValidation;

namespace CategoryProductOrderApi.Validations
{
    public class CategoryDtoValidator: AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            ApplyValidations();
        }
        private void ApplyValidations()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .MinimumLength(3).WithMessage("Category name must be at least 3 characters long.")
                .MaximumLength(255).WithMessage("Category name must not exceed 255 characters.");

        }

    }
}
