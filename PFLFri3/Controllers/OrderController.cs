using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFLFri3.Models;

namespace PFLFri3.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index(int id)
        {
            RootObjectDetail rObjDet = null;
            rObjDet = APIServices.GetProductDetails(id).Result;

            return View(rObjDet);
        }

        [HttpPost]
        public ActionResult OnPost(Order model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Item myItem = new Item
            {
                itemSequenceNumber = 1,
                productID = 9877,
                quantity = 1000
            };

            List<Item> myItemList = new List<Item>() { myItem };

            OrderCustomer myOrderCustomer = new OrderCustomer
            {
                firstName = "Scott",
                lastName = "McCaffrey",
                companyName = "Yellowstone Drones",
                address1 = "135 Pray Rd",
                address2 = "",
                city = "Pray",
                state = "MT",
                postalCode = "59065",
                countryCode = "USA",
                email = "mccaffrey.scott@gmail.com",
                phone = "978.831.7098"
            };

            Order myOrder = new Order
            {
                partnerOrderReference = "Order Ref",
                orderCustomer = myOrderCustomer,
                items = myItemList
            };

            string blank = APIServices.PostOrder(myOrder).Result;

            return View();
        }

    }
}