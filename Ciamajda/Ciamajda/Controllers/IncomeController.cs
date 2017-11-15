
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
    public class IncomeController : Controller
    {
        // GET: Income
        public ActionResult Index()
        {

            IncomeClient client = new IncomeClient();
            ViewBag.incomeList = client.FindAll();

            return View();
        }

        // GET: Income/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Income/Create
        public ActionResult Create()
        {
            IncomeViewModel vm = new IncomeViewModel();
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<SelectListItem> accountidlist = vm.GetAccountList(userId);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var el in accountidlist)
            {
                items.Add(new SelectListItem { Text = el.Text, Value = el.Value });
            }
            ViewBag.accountidlist = items;
            return View("Create");
        }

        // POST: Income/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Income income)
        {
            IncomeClient client = new IncomeClient();
            client.Create(income);
            return RedirectToAction("Index");
        }

        // GET: Income/Edit/5
        public ActionResult Edit(int id)
        {
            IncomeClient client = new IncomeClient();
            IncomeViewModel CVM = new IncomeViewModel();
            CVM.Income = client.Find(id);
            return View("Edit", CVM);
        }

        // POST: Income/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IncomeViewModel CVM)
        {
            IncomeClient client = new IncomeClient();
            client.Edit(CVM.Income);
            return RedirectToAction("Index");
        }

        // GET: Income/Delete/5
        public ActionResult Delete(int id)
        {
            IncomeClient client = new IncomeClient();
            client.Delete(id);
            return RedirectToAction("Index");
        }


        // POST: Income/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here NOT IMPLEMENTED YET MAYBE UNNECESARRY

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}