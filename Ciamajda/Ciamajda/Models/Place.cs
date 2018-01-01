using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciamajda
{
    public partial class Place
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} i nie więcej niż {1} znaków.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} i nie więcej niż {1} znaków.", MinimumLength = 1)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} i nie więcej niż {1} znaków.", MinimumLength = 1)]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Niepoprawny numer")]
        public int Number { get; set; }

        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}
