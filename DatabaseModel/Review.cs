using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseModel
{
    public partial class Review
    {
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public short? Rating { get; set; }
        public string Text { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
