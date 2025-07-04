﻿using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.Carts.Queries
{
    public class GetUserCartQuery : IRequest<List<CartDto>>
    {
        public int UserId { get; }

        public GetUserCartQuery(int userId)
        {
            UserId = userId;
        }
    }
}
