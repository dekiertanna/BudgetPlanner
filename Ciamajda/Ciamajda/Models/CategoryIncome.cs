using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ciamajda
{
    public partial class CategoryIncome
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} i nie więcej niż {1} znaków.", MinimumLength = 1)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}
