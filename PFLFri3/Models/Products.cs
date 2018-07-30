using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFLFri3.Models
{
    //Product Models
    public class Meta
    {
        public string time { get; set; }
        public int statusCode { get; set; }
        public int duration { get; set; }
    }

    public class Prompt
    {
        public string language { get; set; }
        public string text { get; set; }
    }

    public class Description
    {
        public string language { get; set; }
    }

    public class Field
    {
        public string required { get; set; }
        public string visible { get; set; }
        public string type { get; set; }
        public string charlimit { get; set; }
        public string linelimit { get; set; }
        public string fieldname { get; set; }
        public List<Prompt> prompt { get; set; }
        public string @default { get; set; }
        public string orgvalue { get; set; }
        public string htmlfieldname { get; set; }
        public string subtype { get; set; }
        public Description description { get; set; }
    }

    public class Fieldlist
    {
        public List<Field> field { get; set; }
    }

    public class TemplateFields
    {
        public Fieldlist fieldlist { get; set; }
    }

    public class DeliveredPrice
    {
        public string deliveryMethodCode { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public DateTime created { get; set; }
        public string locationType { get; set; }
        public bool isDefault { get; set; }
    }

    public class ProductionSpeed
    {
        public int days { get; set; }
        public bool isDefault { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string sku { get; set; }
        public int productID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public List<object> images { get; set; }
        public int quantityDefault { get; set; }
        public int? quantityMinimum { get; set; }
        public int? quantityMaximum { get; set; }
        public int? quantityIncrement { get; set; }
        public string shippingMethodDefault { get; set; }
        public bool hasTemplate { get; set; }
        public object emailTemplateId { get; set; }
        public DateTime lastUpdated { get; set; }
        public List<object> customValues { get; set; }
        public List<DeliveredPrice> deliveredPrices { get; set; }
        public List<ProductionSpeed> productionSpeeds { get; set; }
        public string productFormat { get; set; }
        public object productRestrictionType { get; set; }
    }

    public class ProductDetails
    {
        public int id { get; set; }
        public int? sku { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public List<object> images { get; set; }
        public List<object> files { get; set; }
        public int quantityDefault { get; set; }
        public int? quantityMinimum { get; set; }
        public int? quantityMaximum { get; set; }
        public int? quantityIncrement { get; set; }
        public string shippingMethodDefault { get; set; }
        public int? emailTemplateId { get; set; }
        public bool hasTemplate { get; set; }
        public TemplateFields templateFields { get; set; }
        public DateTime lastUpdated { get; set; }
        public List<object> customValues { get; set; }
        public List<DeliveredPrice> deliveredPrices { get; set; }
        public List<ProductionSpeed> productionSpeeds { get; set; }
        public string productFormat { get; set; }
        public object productRestrictionType { get; set; }
    }

    public class ResultDetails
    {
        public List<object> errors { get; set; }
        public List<object> messages { get; set; }
        public ProductDetails data { get; set; }
    }

    public class Results
    {
        public List<object> errors { get; set; }
        public List<object> messages { get; set; }
        public List<Product> data { get; set; }
    }

    public class RootObjectDetail
    {
        public Meta meta { get; set; }
        public ResultDetails results { get; set; }
    }

    public class RootObjectProduct
    {
        public Meta meta { get; set; }
        public Results results { get; set; }
    }

    //Order Models
    public class OrderCustomer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string countryCode { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Item
    {
        public int itemSequenceNumber { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public int? productionDays { get; set; }
        public string partnerItemReference { get; set; }
        public string itemFile { get; set; }
    }

    public class Order
    {
        public string partnerOrderReference { get; set; }
        public OrderCustomer orderCustomer { get; set; }
        public List<Item> items { get; set; }
    }
}
