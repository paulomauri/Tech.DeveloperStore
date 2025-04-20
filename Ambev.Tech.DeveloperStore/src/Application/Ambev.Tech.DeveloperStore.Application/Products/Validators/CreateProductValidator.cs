using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Ambev.Tech.DeveloperStore.Application.Products.Validators
{
    public class CreateProductValidator : AbstractValidator<Commands.CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
        }
    }
}
