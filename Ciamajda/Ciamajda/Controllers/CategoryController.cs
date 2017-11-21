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
    public class CategoryController : Controller
    {

        

        // GET: Category  where user id==current user id
        public ActionResult Index()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            CategoryClient client = new CategoryClient();
            ViewBag.Categorylist = client.GetCategoryList(userId);

            return View();
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = new Category
            {
                UserId = userId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category Category)
        {
            CategoryClient client = new CategoryClient();
            client.Create(Category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            CategoryClient client = new CategoryClient();
            client.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            CategoryClient client = new CategoryClient();
            CategoryViewModel CVM = new CategoryViewModel();
            CVM.Category = client.Find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel CVM)
        {
            CategoryClient client = new CategoryClient();
            client.Edit(CVM.Category);
            return RedirectToAction("Index");
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}










