using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.ValueObjects
{
    public class PasswordHash : IEquatable<PasswordHash>
    {
        public string Hash { get; private set; }

        public PasswordHash(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new ArgumentException("Password hash cannot be empty.", nameof(hash));

            Hash = hash;
        }

        public bool Equals(PasswordHash other)
        {
            if (other is null) return false;
            return Hash.Equals(other.Hash);
        }

        public override bool Equals(object obj) => Equals(obj as PasswordHash);
        public override int GetHashCode() => Hash.GetHashCode();
        public override string ToString() => Hash;
    }
}
