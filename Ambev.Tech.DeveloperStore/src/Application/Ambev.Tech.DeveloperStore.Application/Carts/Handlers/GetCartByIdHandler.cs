using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Carts.Queries;
using Ambev.Tech.DeveloperStore.Application.Interface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Handlers
{
    public class GetCartByIdHandler : IRequestHandler<GetCartByIdQuery, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        IMapper _mapper;

        public GetCartByIdHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDto?> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id);
            return cart == null ? null : new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Date = cart.Date,
                Items = _mapper.Map<List<CartProductDto>>(cart.Items)
            };
        }
    }
}
