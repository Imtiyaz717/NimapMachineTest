using MachineTest1.EF;
using MachineTest1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTest1.Controllers
{
    
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly MyContext db;

        public CategoryController()
        {
            db = new MyContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        [HttpGet]
        
        public ActionResult AddNewCategory()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCategory(CategoryMaster CM)
        {
            
            try
            {
             if(ModelState.IsValid)
                {
                    db.TblCategoryMaster.Add(CM);
                    db.SaveChanges();
                    
                    return RedirectToAction("CategoryList");
                }  
               
            }
            catch (DbUpdateException ex)
            {

                ModelState.AddModelError("", "An error occurred while saving the category.");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
            }
            return View(CM);
            
        }

        public ActionResult CategoryList()
        {
            try
            {
                var categories = db.TblCategoryMaster.ToList();
                
                return View(categories);
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving category data.");
                
                return View(new List<CategoryMaster>());
                
            }
           
        }

        [HttpGet]
        
        public ActionResult CategoryDetails(int id)
        {
            try
            {
                var details = db.TblCategoryMaster.FirstOrDefault(x => x.CategoryId == id);
                if(details != null)
                {
                    return View(details);
                }
                else
                {

                    return RedirectToAction("NotFound", "Error");
                }
               

            }
            catch (Exception)
            {

                ViewBag.ErrorMessage = "An error occurred while retrieving category details.";
                return View();
            }
           
        }

        [HttpGet]
        
        public ActionResult UpdateCategory(int id)
        {
            try
            {
                
                var obj = db.TblCategoryMaster.FirstOrDefault(x => x.CategoryId == id);
                if(obj != null)
                {
                    return View(obj);
                }
                else
                {
                    return RedirectToAction("NotFound", "Error");
                }
               
            }
            catch (Exception)
            {

                throw;
            }
           
        }



        [HttpPost]
        public ActionResult UpdateCategory(CategoryMaster CM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(CM).State = System.Data.Entity.EntityState.Modified;
                    
                    db.SaveChanges();
                    return RedirectToAction("CategoryList");
                }
                else
                {
                    ViewBag.UpdatError = "There is an issue while updating data into database!";
                    return View();
                }


            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "An error occurred while updating the category.");
                return View();
            }
        }
            

        [HttpGet]
        
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                var obj = db.TblCategoryMaster.FirstOrDefault(x => x.CategoryId == id);
                if(obj != null)
                {
                    return View(obj);
                }
                else
                {
                    return RedirectToAction("NotFound", "Error");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "There is an error for Deleting data from database!");
                return View();
            }
            
           
            
           
        }


        [HttpPost]
        [ActionName("DeleteCategory")]
        
        public ActionResult DeleteCategoryPost(int id)
        {
            try
            {
                var obj = db.TblCategoryMaster.FirstOrDefault(x => x.CategoryId == id);
                if(obj != null)
                {

                    db.TblCategoryMaster.Remove(obj);
                    db.SaveChanges();
                    return RedirectToAction("CategoryList");
                }
                else
                {
                    return RedirectToAction("NotFound", "Error");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "There is an error for Deleting data from database!");
                return View();
            }
           
           
        }
    }
}