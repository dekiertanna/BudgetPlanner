using System;
using System.Collections.Generic;

namespace Klakier
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public string Name { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DiscardDate { get; set; }
        public decimal Expenses { get; set; }
        public decimal Income { get; set; }
        public string UserId { get; set; }
        public int PortfelId { get; set; }
    }
}
