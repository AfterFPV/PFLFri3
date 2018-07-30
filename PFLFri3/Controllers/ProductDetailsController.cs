using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFLFri3.Models;

namespace PFLFri3.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index(int id)
        {
            RootObjectDetail rObjDet = null;
            rObjDet = APIServices.GetProductDetails(id).Result;

            return View(rObjDet.results.data);
        }
    }
}