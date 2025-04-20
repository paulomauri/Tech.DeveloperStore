using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using MediatR;


namespace Ambev.Tech.DeveloperStore.Application.Auth.Commands
{
    public record LoginCommand(string Username, string Password) : IRequest<AuthTokenDto>;
}
