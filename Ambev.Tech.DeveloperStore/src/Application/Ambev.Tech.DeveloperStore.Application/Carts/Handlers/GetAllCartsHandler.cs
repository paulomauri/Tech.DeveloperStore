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
    public class GetAllCartsHandler : IRequestHandler<GetAllCartsQuery, List<CartDto>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetAllCartsHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<List<CartDto>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.GetAllAsync();

            return _mapper.Map<List<CartDto>>(carts);
        }
    }
}
