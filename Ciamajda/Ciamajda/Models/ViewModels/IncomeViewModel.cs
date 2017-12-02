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
                types.Add(new SelectListItem() { Text = el.Name.ToString(), Value = el.Id.ToString() });

            }



            return types;
        }
        internal List<Account> GetAccountIdList(string userId)
        {
            AccountClient ac = new AccountClient();
            IEnumerable<Account> enumerable = ac.GetAccountList(userId);
            return (List<Account>)enumerable;
        }
        public List<SelectListItem> GetPlaceList(string id)
        {
            PlaceClient ac = new PlaceClient();
            IEnumerable<Place> enumerable = ac.GetPlaceList(id);
            var types = new List<SelectListItem>();
            var iterator = 0;
            foreach (var el in enumerable)
            {

                iterator++;
                types.Add(new SelectListItem() { Text = el.Name.ToString(), Value = el.Id.ToString() });

            }



            return types;
        }

        public List<SelectListItem> GetCategoryIncomeList(string id)
        {
            CategoryIncomeClient ac = new CategoryIncomeClient();
            IEnumerable<CategoryIncome> enumerable = ac.GetCategoryIncomeList(id);
            var types = new List<SelectListItem>();
            var iterator = 0;
            foreach (var el in enumerable)
            {

                iterator++;
                types.Add(new SelectListItem() { Text = el.Name.ToString(), Value = el.Id.ToString() });

            }



            return types;
        }


        public String GetAccountName(int id)
        {
            AccountClient ac = new AccountClient();
            Account account = ac.Find(id);
            return account.Name;
        }

       

        public String GetCategoryName(int id)
        {
            CategoryClient ac = new CategoryClient();
            Category category = ac.Find(id);
            return category.Name;
        }
    }
}
