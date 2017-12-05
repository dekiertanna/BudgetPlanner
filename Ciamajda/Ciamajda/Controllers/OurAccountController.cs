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
    public class OurAccountController : Controller
    {



        // GET: OurAccount  where user id==current user id
        public ActionResult Index()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            AccountClient client = new AccountClient();
            IEnumerable<Account> list= client.GetAccountList(userId);
            ViewBag.accountlist = list;
            ViewBag.size = list.Count();
            return View();
        }

        // GET: OurAccount/Create
        [HttpGet]
        public ActionResult Create()
        {
            Account myModel = new Account();
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            myModel.UserId = userId;
            myModel.CreationDate = DateTime.Now;
            myModel.DiscardDate = DateTime.Now;
            

            return View(myModel);
       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account OurAccount)
        {
            AccountClient client = new AccountClient();
            client.Create(OurAccount);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            AccountClient client = new AccountClient();       
            client.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            AccountClient client = new AccountClient();
            AccountViewModel CVM = new AccountViewModel();
            CVM.Account = client.Find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(AccountViewModel CVM)
        {
            AccountClient client = new AccountClient();
            client.Edit(CVM.Account);
            return RedirectToAction("Index");
        }

        // GET: OurAccount/Details/5
        public ActionResult Details(int id)
        {
            ExpenseClient ex = new ExpenseClient();
            IncomeClient inc = new IncomeClient();
            List<int> accounts = new List<int>();
            accounts.Add(id);
            List<Flow> flows = new List<Flow>();
            ViewBag.exp = ex.FindAll(accounts);
            ViewBag.inc = inc.FindAll(accounts);
            flows.AddRange(ex.FindAll(accounts));
            flows.AddRange(inc.FindAll(accounts));
            flows.Sort(new DateTimeComparator());
            ViewBag.list = flows;
            ViewBag.size = flows.Count;
            return View();
        }
    }
}










