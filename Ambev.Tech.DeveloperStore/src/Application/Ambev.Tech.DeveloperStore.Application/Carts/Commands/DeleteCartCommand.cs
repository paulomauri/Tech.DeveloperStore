using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Commands
{
    public class DeleteCartCommand : IRequest<bool>
    {
        public int Id { get; set; } // setter público

        public DeleteCartCommand() { }

        public DeleteCartCommand(int id)
        {
            Id = id;
        }
    }
}

