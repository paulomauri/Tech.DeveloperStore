using Ambev.Tech.DeveloperStore.Application.Auth.Commands;
using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using Ambev.Tech.DeveloperStore.Application.Common.Interfaces;
using MediatR;


namespace Ambev.Tech.DeveloperStore.Application.Auth.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthTokenDto>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authService.ValidateUserAsync(request.Username, request.Password);

            if (user == null)
                return null;

            var token = _authService.GenerateToken(user);

            return new AuthTokenDto { Token = token };
        }
    }
}
