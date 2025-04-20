using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Users.Queries
{
    public record GetAllUsersQuery(int Page = 1, int Size = 10, string? Order = null) : IRequest<List<UserDto>>;
}
