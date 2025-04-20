using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.ValueObjects
{
    public class Username : IEquatable<Username>
    {
        public string Value { get; private set; }

        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Username cannot be empty.", nameof(value));

            Value = value;
        }

        public bool Equals(Username other)
        {
            if (other is null) return false;
            return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) => Equals(obj as Username);
        public override int GetHashCode() => Value.ToLower().GetHashCode();
        public override string ToString() => Value;
    }
}
