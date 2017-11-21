using System;
using System.Collections.Generic;

namespace Klakier
{
    public partial class Income
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
      
        public DateTime Time { get; set; }
        public bool IsCyclical { get; set; }
        public int? DaysCycle { get; set; }
        public string CurrencyCurrency { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
