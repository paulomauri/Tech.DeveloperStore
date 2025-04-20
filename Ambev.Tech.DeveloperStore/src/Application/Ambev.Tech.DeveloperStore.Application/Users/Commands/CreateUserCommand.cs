using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public UserDto UserDto { get; }

        public CreateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
