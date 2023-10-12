using MachineTest1.EF;
using MachineTest1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTest1.Controllers
{
    
    public class ProductController : Controller
    {
        // GET: Product
        private readonly MyContext db;

        public ProductController()
        {
            db = new MyContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult ProductList()
        {
            try
            {
                int i = 1;
                var list = db.TblProductMaster.ToList();
                var newlist = list.Select(x => new CategoryProductVM()
                {
                    Id =i++,
               
                    ProductID=x.ProductId,
                    ProductName=x.ProductName,
                    CategoryID = x.CategoryId,
                    CategoryName=x.CategoryMaster.CategoryName
                });
               
                    return View(newlist);
               
            }
            catch (Exception ex)
            {
                
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
           
           
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.list = db.TblCategoryMaster.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult AddProduct(ProductMaster PM)
        {
           

            try
            {
                if (PM!=null)
                {
                     
                            db.TblProductMaster.Add(PM);
                            db.SaveChanges();
                            return RedirectToAction("ProductList");
                        
                }
                else
                {
                    return View();
                }
               
            }
            catch (Exception ex)
            {

               ViewBag.AddExp = ex.Message;
                return View();
            }

            
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            try
            {
                var obj = db.TblProductMaster.FirstOrDefault(x => x.ProductId == id);
                
                if (obj != null)
                {
                    return View(obj);
                }
                else
                {
                    ViewBag.notfound = "No Record found for this request!";
                    return View();
                }

            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Message;
                return View();
            }
            
           
           
        }




        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            try
            {
                ViewBag.list = db.TblCategoryMaster.ToList();
                var obj = db.TblProductMaster.First(x => x.ProductId == id);
                
                if (obj != null)
                {
                    return View(obj);
                }
                else
                {
                    ViewBag.NFdata = "This Record is not found in the table";
                    return View();
                }
                
            }
            catch (Exception ex)
            {

                ViewBag.except = ex.Message;
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductMaster PM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                        db.Entry(PM).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("ProductList");
                }
                else
                {
                ViewBag.Model = "Model State is no valid";
                return View();
                }
                

            }
            catch (Exception ex)
            {

               ViewBag.Exception = ex.Message;
                return View();
            }
            //
           
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var obj = db.TblProductMaster.FirstOrDefault(x => x.ProductId == id);
                if (obj != null)
                {
                    return View(obj);
                }
                else
                {
                    ViewBag.NotFound = "Record not found!";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View();
            }
           
           
        }

        [HttpPost]
        [ActionName("DeleteProduct")]
        public ActionResult DeleteProductPost(int id)
        {
            try
            {
                var obj = db.TblProductMaster.FirstOrDefault(x => x.ProductId == id);
                if (obj != null)
                {
                    db.TblProductMaster.Remove(obj);
                    db.SaveChanges();
                    return RedirectToAction("ProductList");
                }
                else
                {
                    ViewBag.NotFound = "Record not found!";
                    return View();
                }

            }
            catch (Exception ex)
            {

                ViewBag.Exception = ex.Message;
                return View();
            }
            
            
           
        }




    }
}
