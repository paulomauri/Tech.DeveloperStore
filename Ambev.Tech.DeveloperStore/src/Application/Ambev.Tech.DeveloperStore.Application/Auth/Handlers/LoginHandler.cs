using Ambev.Tech.DeveloperStore.Application.Auth.Commands;
using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using Ambev.Tech.DeveloperStore.Application.Interface;
using MediatR;


namespace Ambev.Tech.DeveloperStore.Application.Auth.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthTokenDto>
    {
        private readonly IAuthRepository _authRepository;

        public LoginHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<AuthTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authToken = await _authRepository.LoginAsync(new LoginDto() { Username = request.username, Password = request.password});

            return authToken;
        }
    }
}
