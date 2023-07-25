using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace chatApp.Controllers
{
       public class HomeController : Controller 
    { 
      public IActionResult Index() 
      { 
        return View(); 
      } 
      public IActionResult About() 
      { 
        ViewData["Message"] = "Your application description page."; 
        return View(); 
      }
    }
}