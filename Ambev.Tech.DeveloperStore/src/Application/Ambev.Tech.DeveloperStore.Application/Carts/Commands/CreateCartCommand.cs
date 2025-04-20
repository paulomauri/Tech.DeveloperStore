using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Commands
{
    public record CreateCartCommand(int UserId, DateTime Date, List<CartProductDto> Products) : IRequest<CartDto>;
}
