using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciamajda.Models
{
    public class Flow
    {
        [Display(Name = "Czas")]
        [DataType(DataType.DateTime), Required]
        [DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

    }
}
