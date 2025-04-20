using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Auth.Commands
{
    public class ValidateTokenCommand : IRequest<bool>
    {
        public string Token { get; set; }

        public ValidateTokenCommand(string token)
        {
            Token = token;
        }
    }
}
