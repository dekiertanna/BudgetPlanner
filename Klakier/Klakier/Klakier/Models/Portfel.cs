using System;
using System.Collections.Generic;

namespace Klakier
{
    public partial class Portfel
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}
