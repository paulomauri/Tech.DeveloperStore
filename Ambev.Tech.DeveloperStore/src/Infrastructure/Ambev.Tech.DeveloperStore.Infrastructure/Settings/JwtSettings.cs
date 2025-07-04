﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "Ambev.Tech.DeveloperStore";
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpiryInMinutes { get; set; }
    }
}
