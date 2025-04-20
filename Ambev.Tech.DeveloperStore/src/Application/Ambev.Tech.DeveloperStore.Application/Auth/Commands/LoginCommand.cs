using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using MediatR;


namespace Ambev.Tech.DeveloperStore.Application.Auth.Commands
{
    public class LoginCommand : IRequest<AuthTokenDto>
    {
        public string username {  get; set; }
        public string password { get; set; }

        public LoginCommand(string Username, string Password)
        {
            username = Username;
            password = Password;
        }
    }
}
