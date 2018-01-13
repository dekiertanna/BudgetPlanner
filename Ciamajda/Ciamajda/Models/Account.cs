using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ciamajda
{
    public partial class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} i nie więcej niż {1} znaków.", MinimumLength = 1)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} i nie więcej niż {1} znaków.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} i nie więcej niż {1} znaków.", MinimumLength = 6)]
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
