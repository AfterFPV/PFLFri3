using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFLFri3.Models;

namespace PFLFri3.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Order/Add")]
        [HttpPost]
        public IActionResult CreateOrder(IFormCollection items)
        {
            Item myItem = new Item
            {
                itemSequenceNumber = 1,
                productID = int.Parse(items["id"]),
                quantity = int.Parse(items["quantity"])
            };

            List<Item> myItemList = new List<Item>() { myItem };
            
            OrderCustomer myOrderCustomer = new OrderCustomer
            {
                firstName = items["FirstName"],
                lastName = items["LastName"],
                companyName = items["CompanyName"],
                address1 = items["Address1"],
                address2 = items["Address2"],
                city = items["City"],
                state = items["State"],
                postalCode = items["PostalCode"],
                countryCode = items["CountryCode"],
                email = items["Email"],
                phone = items["Phone"]
            };

            string mailingMethod = items["MailingMethod"];
            string mailingCode = mailingMethod.Substring(0, mailingMethod.IndexOf(' '));
            Mailing myMailings = new Mailing()
            {
                mailingSequenceNumber = 1,
                mailingMethod = mailingCode
            };

            List<Mailing> myMailingsList = new List<Mailing>() { myMailings };

            Order myOrder = new Order
            {
                partnerOrderReference = "Order Ref",
                orderCustomer = myOrderCustomer,
                items = myItemList,
                mailings = myMailingsList
            };

            RootObjectOrder rObj = APIServices.PostOrder(myOrder).Result;

            return View("~/Views/Order/Index.cshtml", rObj.results.data);
        }

    }
}