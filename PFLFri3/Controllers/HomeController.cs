using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PFLFri3.Models;


namespace PFLFri3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //TODO Switch GetProducts Call back on
            RootObjectProduct rObj = null;
            rObj = APIServices.GetProducts().Result;
            //rObj = APIServices.LoadJsonLocal();

            return View(rObj);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
