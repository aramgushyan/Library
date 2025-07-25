﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = null!;
        public int ExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationDaysForRefresh { get; set; }

    }
}
