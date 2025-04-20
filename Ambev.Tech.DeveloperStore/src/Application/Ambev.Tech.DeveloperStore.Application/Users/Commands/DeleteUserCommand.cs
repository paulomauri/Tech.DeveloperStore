using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Users.Commands
{

    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; } // setter público

        public DeleteUserCommand() { }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
