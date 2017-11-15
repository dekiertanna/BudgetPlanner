using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciamajda.Models;
using Ciamajda.Models.APIClients;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ciamajda.Models.ViewModels
{
    public class IncomeViewModel
    {
        public Income Income { get; set; }


        public List<SelectListItem> GetAccountList(string id)
        {
            AccountClient ac = new AccountClient();
            IEnumerable<Account> enumerable = ac.GetAccountList(id);
            var types = new List<SelectListItem>();
            var iterator = 0;
            foreach (var el in enumerable)
            {

                iterator++;
                types.Add(new SelectListItem() { Text = el.Id.ToString(), Value = el.Id.ToString() });

            }



            return types;
        }


    }
}
