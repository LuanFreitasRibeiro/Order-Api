using FluentValidation;
using Orders.Domain.Models;
using Orders.Domain.Models.Request.Customer;

namespace Orders.AppService.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CreateCustomerValidator()
        {
            ValidateName();
            ValidateEmail();
        }

        private void ValidateName()
        {
            this.RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }

        private void ValidateEmail()
        {
            this.RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .EmailAddress()
                .WithMessage("{PropertyName} is invalid.");
        }
    }
}
