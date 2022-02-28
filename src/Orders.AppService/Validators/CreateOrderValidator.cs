using FluentValidation;
using Orders.Domain.Models.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
