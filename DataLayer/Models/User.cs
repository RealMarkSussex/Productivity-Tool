﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; }
    }
}