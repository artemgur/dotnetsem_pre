using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseModel
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
