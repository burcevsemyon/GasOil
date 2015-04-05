using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasOil.Models;
using GasOil.db;

namespace GasOil.Controllers
{
    public class ProductsController : BaseController
    {
        //
        // GET: /Products/

        private ProductsPageModel GetModel(int groupId)
        {
            var model = new ProductsPageModel();
            try
            {
                using (var context = new dbEntities())
                {
                    model.Products = context.Products.Where(p => groupId <= 0 || p.GroupId == groupId).Select(p => new ProductModel { Id = p.Id, Name = p.Name, UnitOfMeasurement = p.UnitOfMeasurement.Name }).ToList();
                    model.ProductsGroups = context.ProductsGroups.ToList();
                }
            }
            catch
            {
            }

            return model;
        }

        public ActionResult Passports()
        {
            return View("ProductPassports");
        }

        public ActionResult Index()
        {
            ViewBag.groupId = -1;

            return View("Index", GetModel(-1));
        }

        public ActionResult DeleteCategory(int groupId)
        {
            var model = new List<ProductsGroup>();
            try
            {
                using (var context = new dbEntities())
                {
                    var group = context.ProductsGroups.FirstOrDefault(g => g.id == groupId);

                    context.ProductsGroups.DeleteObject(group);

                    context.SaveChanges();

                    model = context.ProductsGroups.ToList();
                }
            }
            catch
            {
            }

            return View("EditCategories", model);
        }

        public ActionResult EditCategorу(int groupId)
        {
            ProductsGroup group = null;
            try
            {
                using (var context = new dbEntities())
                {
                    group = context.ProductsGroups.FirstOrDefault(g => g.id == groupId);
                }
            }
            catch
            {
            }

            return View("EditCategory", group);
        }

        [HttpPost]
        public RedirectToRouteResult EditCategorу(int groupId, string groupName)
        {
            ProductsGroup group = null;
            try
            {
                using (var context = new dbEntities())
                {
                    group = context.ProductsGroups.FirstOrDefault(g => g.id == groupId);

                    group.Name = groupName;

                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.InnerException.Message;
            }

            return RedirectToAction("EditCategories");
        }

        public ActionResult EditCategories()
        {
            var model = new List<ProductsGroup>();
            try
            {
                using (var context = new dbEntities())
                {
                    model = context.ProductsGroups.ToList();
                }
            }
            catch
            {
            }

            ViewBag.Error = TempData["Error"];

            return View("EditCategories", model);
        }

        public ActionResult AddCategory(int groupId)
        {
            ViewBag.groupId = groupId;

            return View("AddCategory");
        }

        [HttpPost]
        public ActionResult AddCategory(int groupId, string groupName)
        {
            ViewBag.groupId = groupId;

            try
            {
                using (var context = new dbEntities())
                {
                    var group = new ProductsGroup {Name = groupName};

                    context.ProductsGroups.AddObject(group);

                    context.SaveChanges();
                }
            }
            catch
            {
            }

            return View("Index", GetModel(groupId));
        }

        public ActionResult ShowProductsGroup(int groupId)
        {
            ViewBag.groupId = groupId;

            return View("Index", GetModel(groupId));
        }

        public ActionResult Add()
        {
            ViewBag.groupId = -1;

            var model = new EditProductsPageModel();
            try
            {
                using (var context = new dbEntities())
                {
                    model.ProductsGroups = context.ProductsGroups.ToList();
                    model.UnitOfMeasurements = context.UnitOfMeasurements.ToList();
                }
            }
            catch
            {
            }

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Add(string productName, int groupId, int unitId)
        {
            ViewBag.groupId = groupId;
            
            try
            {
                using (var context = new dbEntities())
                {
                    var product = new Product
                                      {
                                          Name = productName,
                                          GroupId = groupId,
                                          UnitOfMeasurementId = unitId
                                      };

                    context.Products.AddObject(product);

                    context.SaveChanges();
                }
            }
            catch
            {
            }

            return View("Index", GetModel(groupId));
        }

        public ActionResult Edit(int groupId, int productId)
        {
            ViewBag.groupId = groupId;

            var model = new EditProductsPageModel();
            try
            {
                using (var context = new dbEntities())
                {
                    model.Product = context.Products.FirstOrDefault(p => p.Id == productId);
                    model.ProductsGroups = context.ProductsGroups.ToList();
                    model.UnitOfMeasurements = context.UnitOfMeasurements.ToList();
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View("Edit", model);
        }

        public ActionResult Delete(int groupId, int productId)
        {   
            try
            {
                using (var context = new dbEntities())
                {
                    var product = context.Products.FirstOrDefault(p => p.Id == productId);

                    context.DeleteObject(product);

                    context.SaveChanges();
                }
            }
            catch
            {
            }

            return View("Index", GetModel(groupId));
        }

        public ActionResult SaveProduct(int productId, int groupId, int oldGroupId, string productName, int? unitId)
        {
            ViewBag.groupId = groupId;

            try
            {
                using (var context = new dbEntities())
                {
                    Product product = context.Products.FirstOrDefault(p => p.Id == productId);

                    if (product != null)
                    {
                        product.Name = productName;
                        product.GroupId = groupId;
                        product.UnitOfMeasurementId = unitId;                        
                    }

                    context.SaveChanges();
                }
            }
            catch
            {
            }

            return View("Index", GetModel(oldGroupId));
        }
    }
}
