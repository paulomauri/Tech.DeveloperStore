using Ambev.Tech.DeveloperStore.Application.Auth.Queries;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Auth.Handlers
{
    public class ValidateTokenHandler : IRequestHandler<ValidateTokenQuery, UserDto>
    {
        private readonly IAuthService _authService;

        public ValidateTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<UserDto> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _authService.ValidateTokenAsync(request.Token);

            return user;
        }
    }
}
