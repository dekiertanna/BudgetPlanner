using System;
using System.Collections.Generic;

namespace Ciamajda
{
    public partial class Account
    {
       

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]
        public DateTime CreationDate { get; set; }
        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]
        public DateTime DiscardDate { get; set; }
        public decimal Expenses { get; set; }
        public decimal Income { get; set;}
        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]

        public string UserId { get; set; }
        public int PortfelId { get; set; }

     
    }
}
