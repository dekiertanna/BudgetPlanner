﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ciamajda.Models.APIClients;
using Ciamajda.Models;

namespace Ciamajda
{
    public partial class Income:Flow
    {
        public int Id { get; set; }
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }
       
        [Display(Name = "Dochód cykliczny")]
        public bool IsCyclical { get; set; }
        [Display(Name = "Długość cyklu")]
        public int? DaysCycle { get; set; }
        [Display(Name = "Waluta")]
        public string CurrencyCurrency { get; set; }
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        [Display(Name = "Konto")]
        public int AccountId { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }


       
    }
}
