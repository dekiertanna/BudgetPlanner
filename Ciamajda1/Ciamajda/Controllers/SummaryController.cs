using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ciamajda.Controllers
{
    public class SummaryController : Controller
    {

        // GET: Summary
      public IActionResult Index()
        {
            return View();
        }

        // GET: Summary/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Summary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Summary/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Summary/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Summary/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Summary/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Summary/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}