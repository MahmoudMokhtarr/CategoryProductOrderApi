using CategoryProductOrderApi.Dtos;
using FluentValidation;

namespace CategoryProductOrderApi.Validations
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            ApplyValidations();
        }
        private void ApplyValidations()
        {
            RuleFor(o => o.OrderDate)
             .NotEmpty().WithMessage("Order date is required.")
             .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Order date cannot be in the future.");

            RuleFor(o => o.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .MinimumLength(3).WithMessage("Customer name must be at least 3 characters long.")
                .MaximumLength(150).WithMessage("Customer name must not exceed 150 characters.");

        }

    }
}
