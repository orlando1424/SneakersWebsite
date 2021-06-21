using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakersWebsite.Controllers
{
    public class ShoesController : Controller
    {
        public IActionResult AllShoes()
        {
            return View();
        }
    }
}
