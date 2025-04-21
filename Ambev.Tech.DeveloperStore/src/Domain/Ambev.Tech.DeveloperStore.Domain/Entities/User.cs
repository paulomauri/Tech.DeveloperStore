using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ambev.Tech.DeveloperStore.Domain.Entities
{
    public class User
    {
        public User() { }

        public User(string email, string name, string password)
        {
            Email = email;
            Username = name;
            Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
