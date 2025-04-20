using Ambev.Tech.DeveloperStore.Application.Auth.Commands;
using Ambev.Tech.DeveloperStore.Application.Auth.Queries;
using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Auth.Handlers
{
    public class ValidateTokenHandler : IRequestHandler<ValidateTokenQuery, bool>
    {
        private readonly IAuthRepository _authRepository;

        public ValidateTokenHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<bool> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            // Realiza a validação do token e retorna um valor booleano
            return await _authRepository.ValidateTokenAsync(request.Token);
        }

    }
}
