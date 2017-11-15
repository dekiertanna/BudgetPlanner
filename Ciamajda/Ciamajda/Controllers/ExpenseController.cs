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

            ExpenseClient client = new ExpenseClient();
            ViewBag.expenselist = client.FindAll();

            return View();
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
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            ExpenseClient client = new ExpenseClient();
            client.Create(expense);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ExpenseClient client = new ExpenseClient();
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
    }
}
   
   

      

 

       

      
