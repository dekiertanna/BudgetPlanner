using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciamajda.Models.ViewModels
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
            DateTime date = DateTime.Now; 
           // String s=date.ToString("yyyy-MM-dd HH:mm:ss");
            this.ReturnDate = date;
        }
        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]

        public string UserId { get; set; }

        public DateTime ReturnDate { get; set; }

        public Account Account { get; set; }



    }
}
