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
    public class PlaceController : Controller
    {



        // GET: Place where user id==current user id 
        public ActionResult Index()
        {
            ClaimsPrincipal currentUser = User;

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            PlaceClient client = new PlaceClient();
            ViewBag.Placelist = client.GetPlaceList(userId);


            return View();
        }

        // GET: Place/Create
        [HttpGet]
        public ActionResult Create()
        {
            ClaimsPrincipal currentUser = User;

         
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Uid = userId;
           

            var model = new Place
            {
                UserId = userId
            };
            return View(model);
        }

       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Place Place)
        {
            PlaceClient client = new PlaceClient();
            client.Create(Place);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            PlaceClient client = new PlaceClient();
            client.Delete(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            PlaceClient client = new PlaceClient();
            PlaceViewModel CVM = new PlaceViewModel();
            CVM.Place = client.Find(id);
            return View("Edit", CVM.Place);
        }

        [HttpPost]
        public ActionResult Edit(Place CVM)
        {
            PlaceClient client = new PlaceClient();
            client.Edit(CVM);
            return RedirectToAction("Index");
        }

        // GET: Place/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}










