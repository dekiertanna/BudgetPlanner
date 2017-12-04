using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Ciamajda.Models.ViewModels;
using Ciamajda.Models.APIClients;
using Ciamajda.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ciamajda.Controllers
{
    public class ExpenseController : Controller
    {
     


        // GET: Expense  
        public ActionResult Index()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            ExpenseClient client = new ExpenseClient();
            ExpenseViewModel md = new ExpenseViewModel();
            List<Account> aclist = md.GetAccountIdList(userId);
            List<int> accounts = new List<int>();
            foreach (var el in aclist)
            {
                accounts.Add(el.Id);
            }
            ViewBag.expenselist = client.FindAll(accounts);
           
            ViewBag.expenseviewmodel = md;
            return View(md);
        }

        // GET: Expense/Create
        [HttpGet]
        public ActionResult Create()
        {
            ExpenseViewModel vm = new ExpenseViewModel();
            ClaimsPrincipal currentUser = User;
           
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            List<SelectListItem> accountidlist = vm.GetAccountList(userId);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var el in accountidlist)
            {
                items.Add(new SelectListItem { Text = el.Text, Value = el.Value });
            }

            ViewBag.accountidlist=items;

            List<SelectListItem> categorylist = vm.GetCategoryList(userId);
            List<SelectListItem> categories = new List<SelectListItem>();
            foreach (var el in categorylist)
            {
                categories.Add(new SelectListItem { Text = el.Text, Value = el.Value });
            }

            ViewBag.categorylist = categories;

            List<SelectListItem> placelist = vm.GetPlaceList(userId);
            List<SelectListItem> places = new List<SelectListItem>();
            foreach (var el in placelist)
            {
                places.Add(new SelectListItem { Text = el.Text, Value = el.Value });
            }

            ViewBag.placelist = places;
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            ExpenseClient client = new ExpenseClient();
            client.Create(expense);
            refreshBalance(expense.AccountId, expense.Amount, 0, 'c');
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ExpenseClient client = new ExpenseClient();
            Expense expense = client.Find(id);
            refreshBalance(expense.AccountId, expense.Amount, 0, 'd');
            client.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            ExpenseClient client = new ExpenseClient();
            ExpenseViewModel CVM = new ExpenseViewModel();
            CVM.Expense = client.Find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(ExpenseViewModel CVM)
        {
            ExpenseClient client = new ExpenseClient();
            client.Edit(CVM.Expense);
            return RedirectToAction("Index");
        }

        // GET: Expense/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void refreshBalance(int id, decimal amount, decimal oldamount, char action) //action c=create e=edit d=delete
        {
            AccountClient ac = new AccountClient();
            Account account = ac.Find(id);

            if (action == 'c')
            {
                account.Expenses += amount;
                account.Balance -= amount;

            }
            else
            {
                if (action == 'e')
                {

                    account.Expenses -= oldamount;
                    account.Balance += oldamount;
                    account.Expenses += amount;
                    account.Balance -= amount;
                }
                else
                {
                    if (action == 'd')
                    {

                        account.Expenses -= amount;
                        account.Balance += amount;
                    }
                }
            }
            ac.Edit(account);

        }//refreshBalance()
    }
}
   
   

      

 

       

      
