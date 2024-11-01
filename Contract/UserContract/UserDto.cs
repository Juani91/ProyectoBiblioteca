﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.UserContract
{
    public class UserDto
    {
        public class UserRequest
        {

            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public class UserResponse
        {
            public int Id { get; set; }
            public string Email { get; set; } = string.Empty;
        }
    }
}
