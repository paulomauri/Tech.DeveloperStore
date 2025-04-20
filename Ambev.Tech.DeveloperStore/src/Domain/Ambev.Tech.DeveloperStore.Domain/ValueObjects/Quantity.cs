using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.ValueObjects
{
    public class Quantity : IEquatable<Quantity>
    {
        public int Value { get; private set; }

        public Quantity(int value)
        {
            if (value < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(value));

            Value = value;
        }

        public bool Equals(Quantity other)
        {
            if (other is null) return false;
            return Value == other.Value;
        }

        public override bool Equals(object obj) => Equals(obj as Quantity);
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
    }
}
