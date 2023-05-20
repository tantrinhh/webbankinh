using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbankinh.Context;
namespace webbankinh.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        webbankinhEntities objwebbankinhEntities = new webbankinhEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = objwebbankinhEntities.products.ToList();
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {         
            return View();
        }
        [HttpPost]
        public ActionResult Create(product objproduct)
        {
            try
            {
                if (objproduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objproduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objproduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyyMMddhhmmss")) + extension;
                    objproduct.avatar = fileName;
                    objproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/a/images/"), fileName));
                }
                objwebbankinhEntities.products.Add(objproduct);
                objwebbankinhEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
           
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            
            var objProduct = objwebbankinhEntities.products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult delete(int id)
        {

            var objProduct = objwebbankinhEntities.products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult delete(product objpro)
        {

            var objProduct = objwebbankinhEntities.products.Where(n => n.id == objpro.id).FirstOrDefault();
            objwebbankinhEntities.products.Remove(objProduct);
            objwebbankinhEntities.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult edit(int id)
        {

            var objProduct = objwebbankinhEntities.products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult edit(int id,product objproduct)
        {

            if (objproduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objproduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objproduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyyMMddhhmmss")) + extension;
                objproduct.avatar = fileName;
                objproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/a/images/"), fileName));
            }
            objwebbankinhEntities.Entry(objproduct).State = EntityState.Modified;
            objwebbankinhEntities.SaveChanges();

            return RedirectToAction("index");
        }
    }
}