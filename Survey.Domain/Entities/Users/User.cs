﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; }
    }
}
