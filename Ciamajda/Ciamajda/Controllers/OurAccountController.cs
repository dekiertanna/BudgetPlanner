using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ciamajda.Controllers
{
    public class OurAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}