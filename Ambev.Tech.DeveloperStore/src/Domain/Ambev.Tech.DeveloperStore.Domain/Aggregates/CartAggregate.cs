using Ambev.Tech.DeveloperStore.Domain.Entities;
using Ambev.Tech.DeveloperStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.Aggregates
{
    public class CartAggregate
    {
        public Cart Cart { get; private set; }

        public CartAggregate(Cart cart)
        {
            Cart = cart;
        }
    }
}
