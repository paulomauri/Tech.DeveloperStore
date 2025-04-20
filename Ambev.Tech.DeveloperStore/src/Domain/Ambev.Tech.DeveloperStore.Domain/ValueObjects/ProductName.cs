using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.ValueObjects
{
    public class ProductName : IEquatable<ProductName>
    {
        public string Name { get; private set; }

        public ProductName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.", nameof(name));

            Name = name;
        }

        public bool Equals(ProductName other)
        {
            if (other is null) return false;
            return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) => Equals(obj as ProductName);
        public override int GetHashCode() => Name.ToLower().GetHashCode();
        public override string ToString() => Name;
    }
}
