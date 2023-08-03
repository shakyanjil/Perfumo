using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        DB obj = new DB();
        // GET: Product
        public ActionResult Index()
        {
            ProductViewModel model = new ProductViewModel();
            model.ProductList = obj.Products.Where(x => x.Prod_ID > 0).ToList();
            return View(model);
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new Product
                {
                    Prod_Name = model.Prod_Name,
                    Prod_Type = model.Prod_Type,
                    Prod_Price = model.Prod_Price,
                    Prod_Description = model.Prod_Desc,
                };
                obj.Products.Add(data);
                obj.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = obj.Products.Find(id);
                obj.Products.Remove(data);
                obj.SaveChanges();
                return Json(new { success = true, msg = "Application Delete Successfully", JsonRequestBehavior.AllowGet });
            }
            catch
            {
                return Json(new { success = false, msg = "Fail to Delete", JsonRequestBehavior.AllowGet });
            }
        }
        public ActionResult EditProduct(int id)
        {
            ProductViewModel model = new ProductViewModel();
            var data = obj.Products.Where(x => x.Prod_ID == id).FirstOrDefault();
            model.Prod_Name = data.Prod_Name;
            model.Prod_Type = data.Prod_Type;
            model.Prod_Price = data.Prod_Price;
            model.Prod_Desc = data.Prod_Description;
            model.Prod_Id = data.Prod_ID;
            return View("Edit",model);
        }
        [HttpPost]
        public ActionResult EditProduct(ProductViewModel model)
        {
            var data = obj.Products.Where(x => x.Prod_ID == model.Prod_Id).FirstOrDefault();
            var entry = new Product
            {
                Prod_Name = model.Prod_Name,
                Prod_Price = model.Prod_Price,
                Prod_Description = model.Prod_Desc,
                Prod_Type = model.Prod_Type,
                Prod_ID= model.Prod_Id
            };
            obj.Products.Remove(data);
            obj.Products.Add(entry);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}