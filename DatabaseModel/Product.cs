using System;
using System.Collections.Generic;
using DatabaseCSharp;

#nullable disable

namespace DatabaseModel
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public short? Rating { get; set; }
        public int? ReviewsNumber { get; set; }
        public string Manufacturer { get; set; }
        
        public ProductType ProductType { get; set; }
        
        public SpecsTable SpecsTable { get; set; }
    }
}
