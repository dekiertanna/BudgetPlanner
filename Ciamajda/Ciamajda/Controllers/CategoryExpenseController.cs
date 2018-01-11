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
    public class CategoryExpenseController : Controller
    {



        // GET: Category  where user id==current user id
        public ActionResult Index()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            CategoryExpenseClient client = new CategoryExpenseClient();
            ViewBag.CategoryExpenselist = client.GetCategoryExpenseList(userId);

            return View();
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = new CategoryExpense
            {
                UserId = userId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryExpense CategoryExpense)
        {
            CategoryExpenseClient client = new CategoryExpenseClient();
            client.Create(CategoryExpense);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            CategoryExpenseClient client = new CategoryExpenseClient();
            client.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CategoryExpenseClient client = new CategoryExpenseClient();
            CategoryExpenseViewModel CEVM = new CategoryExpenseViewModel();
            CEVM.CategoryExpense = client.Find(id);
            return View("Edit", CEVM.CategoryExpense);
        }
        [HttpPost]
        public ActionResult Edit(CategoryExpense CEVM)
        {
            CategoryExpenseClient client = new CategoryExpenseClient();
            client.Edit(CEVM);
            return RedirectToAction("Index");
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}










