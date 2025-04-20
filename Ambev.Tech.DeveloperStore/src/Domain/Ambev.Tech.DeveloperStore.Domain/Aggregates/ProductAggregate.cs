using Ambev.Tech.DeveloperStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.Aggregates
{
    public class ProductAggregate
    {
        public Product Product { get; private set; }

        public ProductAggregate(Product product)
        {
            Product = product;
        }

    }
}
