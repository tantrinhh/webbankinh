using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbankinh.Context;
namespace webbankinh.Controllers
{
    public class CategoryController : Controller
    {
        webbankinhEntities objwebbankinhEntities = new webbankinhEntities();
        // GET: Category
        public ActionResult Index()
        {
            var lstcategory = objwebbankinhEntities.categories.ToList();
            return View(lstcategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var lstproduct = objwebbankinhEntities.products.Where(n => n.categoryid == Id).ToList();
            return View(lstproduct);
        }
    }
}