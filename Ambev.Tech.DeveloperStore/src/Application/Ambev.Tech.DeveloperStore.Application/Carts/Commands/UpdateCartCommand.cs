using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Commands
{
    public class UpdateCartCommand : IRequest<CartDto>
    {
        public int Id { get; }
        public CartDto CartDto { get; }

        public UpdateCartCommand(int id, CartDto cartDto)
        {
            Id = id;
            CartDto = cartDto;
        }
    }
}
