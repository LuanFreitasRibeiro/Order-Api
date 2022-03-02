using FluentValidation;
using Orders.Domain.Models.Request.Order;

namespace Orders.AppService.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderRequest>
    {
        public CreateOrderValidator()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            this.RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}
