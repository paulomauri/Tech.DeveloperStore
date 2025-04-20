using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Auth.Queries
{
    public class ValidateTokenQuery : IRequest<UserDto>
    {
        public string Token { get; set; }

        public ValidateTokenQuery(string token)
        {
            Token = token;
        }
    }
}
