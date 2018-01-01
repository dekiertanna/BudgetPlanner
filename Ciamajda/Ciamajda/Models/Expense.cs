using Ciamajda.Models;
using Ciamajda.Models.APIClients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ciamajda.Extensions;

namespace Ciamajda
{
    public partial class Expense :Flow
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Niepoprawna kwota")]
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }

        [Display(Name = "Miejsce")]
        public int Place { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Wydatek cykliczny")]
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

        [Display(Name="Tytuł")]
        public string Title { get; set; }

        [Display(Name ="Opis")]
        public string Description { get; set; }
    }
}
