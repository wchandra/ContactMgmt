﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service
{
    public class Contact
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }

        public int Status { get; set; }
    }
}
