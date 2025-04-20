using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Queries
{
    public class GetCartByIdQuery : IRequest<CartDto>
    {
        public int Id { get; set; }

        public GetCartByIdQuery() { } // <- Adiciona esse construtor vazio

        public GetCartByIdQuery(int id)
        {
            Id = id;
        }
    }
}
