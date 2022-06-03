using System;
using System.Collections.Generic;
using DatabaseCSharp;

#nullable disable

namespace DatabaseModel
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int[] Products { get; set; }
        public int Cost { get; set; }
        
        public OrderStatus OrderStatus { get; set; }
    }
}
