using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbankinh.Context;
namespace webbankinh.Controllers
{
    public class ShoppingCartController : Controller
    {
        webbankinhEntities objwebbankinhEntities = new webbankinhEntities();
        public ActionResult Index()
        {
            var json = Request.Cookies.Get("cart").Value;
            var cart = JsonConvert.DeserializeObject<Cart[]>(json);
            var ids = cart.Select(x => x.Id).ToArray();
            var products = objwebbankinhEntities.products.Where(x => ids.Contains(x.id)).ToList();
            var view = new ShoppingCartView();
            view.Products = cart.Select(c => products.Select(p => new Cart {
                Id = p.id,
                Name = p.name,
                Description = p.fulldescription,
                Price = p.price,
                PriceDiscount = p.pricediscount,
                Quantity = c.Quantity
            }).First(p => p.Id == c.Id)).ToArray();
            return View(view);
        }
    }

    public class ShoppingCartView
    {
        public Cart[] Products { get; set; }
        public double? Total { get => Products.Sum(x => x.Price * x.Quantity); }
    }

    public class Cart
    {
        public int Id;
        public int Quantity;
        public double? Price;
        public double? PriceDiscount;
        public string Name;
        public string Description;
       // public string avatar;
    }
}