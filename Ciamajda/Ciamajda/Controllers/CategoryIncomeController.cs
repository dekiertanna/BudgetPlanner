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
    public class CategoryIncomeController : Controller
    {



        // GET: Category  where user id==current user id
        public ActionResult Index()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            CategoryIncomeClient client = new CategoryIncomeClient();
            ViewBag.CategoryIncomelist = client.GetCategoryIncomeList(userId);

            return View();
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = new CategoryIncome
            {
                UserId = userId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryIncome CategoryIncome)
        {
            CategoryIncomeClient client = new CategoryIncomeClient();
            client.Create(CategoryIncome);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            CategoryIncomeClient client = new CategoryIncomeClient();
            client.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            CategoryIncomeClient client = new CategoryIncomeClient();
            CategoryIncomeViewModel CIVM = new CategoryIncomeViewModel();
            CIVM.CategoryIncome = client.Find(id);
            return View("Edit", CIVM);
        }
        [HttpPost]
        public ActionResult Edit(CategoryIncomeViewModel CIVM)
        {
            CategoryIncomeClient client = new CategoryIncomeClient();
            client.Edit(CIVM.CategoryIncome);
            return RedirectToAction("Index");
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}










