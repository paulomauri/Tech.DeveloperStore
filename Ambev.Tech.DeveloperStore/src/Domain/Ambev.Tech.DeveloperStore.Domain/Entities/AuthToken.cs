using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Domain.Entities
{
    public class AuthToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
