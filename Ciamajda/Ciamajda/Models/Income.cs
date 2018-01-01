using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ciamajda.Extensions;
using Ciamajda.Models.APIClients;
using Ciamajda.Models;

namespace Ciamajda
{
    public partial class Income : Flow
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Niepoprawna kwota")]
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Dochód cykliczny")]
        public bool IsCyclical { get; set; }

        [RequiredIf(nameof(IsCyclical), true, ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Długość cyklu")]
        public int? DaysCycle { get; set; }

        [RequiredIf(nameof(IsCyclical), true, ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Rodzaj Cyklu")]
        public int? CycleType { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Waluta")]
        public string CurrencyCurrency { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Konto")]
        public int AccountId { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }  
    }
}
