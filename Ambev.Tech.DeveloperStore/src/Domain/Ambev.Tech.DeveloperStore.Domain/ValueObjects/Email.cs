using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.ValueObjects
{
    public class Email : IEquatable<Email>
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email cannot be empty.", nameof(address));

            if (!address.Contains("@"))
                throw new ArgumentException("Invalid email format.", nameof(address));

            Address = address;
        }

        public bool Equals(Email other)
        {
            if (other is null) return false;
            return Address.Equals(other.Address, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) => Equals(obj as Email);
        public override int GetHashCode() => Address.ToLower().GetHashCode();
        public override string ToString() => Address;
    }
}
