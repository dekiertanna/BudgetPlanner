using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciamajda.Models;
using Ciamajda.Models.APIClients;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ciamajda.Models.ViewModels
{
    public class ExpenseViewModel
    {
        public Expense Expense { get; set; }


        public List<SelectListItem> GetAccountList(string id)
        {
            AccountClient ac = new AccountClient();
            IEnumerable<Account> enumerable = ac.GetAccountList(id);
            var types = new List<SelectListItem>();
            var iterator = 0;
            foreach (var el in enumerable)
            {
                
                iterator++;
                types.Add(new SelectListItem() { Text=el.Name.ToString(), Value =el.Id.ToString()});
               
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

        public List<SelectListItem> GetCategoryExpenseList(string id)
        {
            CategoryExpenseClient ac = new CategoryExpenseClient();
            IEnumerable<CategoryExpense> enumerable = ac.GetCategoryExpenseList(id);
            var types = new List<SelectListItem>();
            var iterator = 0;
            foreach (var el in enumerable)
            {

                iterator++;
                types.Add(new SelectListItem() { Text = el.Name.ToString(), Value = el.Id.ToString() });

            }



            return types;
        }

       

        public String GetAccountName(int AccountId)
        {
            AccountClient ac = new AccountClient();
            Account account = ac.Find(AccountId);
            return account.Name;
        }

        public String GetPlaceName(int Place)
        {
            PlaceClient ac = new PlaceClient();
            Place place = ac.Find(Place);
            return place.Name;
        }

        public String GetCategoryName(int CategoryId)
        {
            CategoryClient ac = new CategoryClient();
            Category category = ac.Find(CategoryId);
            return category.Name;
        }

    }
}
