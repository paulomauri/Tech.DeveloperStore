using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Validators
{
    public class CartDtoValidator : AbstractValidator<CartDto>
    {
        public CartDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("ID do usuário inválido.");

            RuleForEach(x => x.Items).SetValidator(new CartProductDtoValidator());
        }
    }
}
