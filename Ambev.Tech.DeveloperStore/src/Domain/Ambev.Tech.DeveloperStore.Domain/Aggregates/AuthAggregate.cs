using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Tech.DeveloperStore.Domain.Entities;


namespace Ambev.Tech.DeveloperStore.Domain.Aggregates
{
    public class AuthAggregate
    {
        public AuthToken Auth { get; private set; }

        public AuthAggregate(AuthToken auth)
        {
            Auth = auth;
        }

    }
}
