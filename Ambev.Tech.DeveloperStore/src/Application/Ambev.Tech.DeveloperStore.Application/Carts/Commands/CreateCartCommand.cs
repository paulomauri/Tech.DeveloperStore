using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Commands
{
    public class CreateCartCommand : IRequest<CartDto>
    {
        public CartDto CartDto { get; }

        public CreateCartCommand(CartDto cartDto)
        {
            CartDto = cartDto;
        }
    }
}
