using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbankinh.Context;
namespace webbankinh.Controllers
{
    public class ProductController : Controller
    {
        webbankinhEntities objwebbankinhEntities = new webbankinhEntities();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objwebbankinhEntities.products.Where(n => n.id==Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}