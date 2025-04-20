using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; }
        public UserDto UserDto { get; }

        public UpdateUserCommand(int id, UserDto userDto)
        {
            Id = id;
            UserDto = userDto;
        }
    }
}
