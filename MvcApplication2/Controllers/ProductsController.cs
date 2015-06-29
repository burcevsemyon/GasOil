using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasOil.Models;
using GasOil.DataModel;
using MvcApplication2.BusinessObjects;

namespace GasOil.Controllers
{
    public class ProductsController : BaseController
    {
        //
        // GET: /Products/

        private ProductsPageModel GetModel(long? groupId)
        {
            var model = new ProductsPageModel();
            using (var context = new GasOilEntities())
            {
                model.Products = context.Products.Where(p => groupId == -1 || p.GroupId == groupId).Select(p => new ProductModel { ProductId = p.Id, Name = p.Name, UnitOfMeasurementId = p.UnitOfMeasurementId, UnitOfMeasurementName = p.UnitOfMeasurement != null ? p.UnitOfMeasurement.Name: null }).ToList();
                model.ProductsGroups = context.ProductsGroups.ToList();
            }

            return model;
        }

        public ActionResult Passports()
        {
            return View("ProductPassports");
        }

        public ActionResult Certificates()
        {
            return View("ProductCertificates");
        }

        public ActionResult Index()
        {
            ViewBag.groupId = null;

            return View("Index", GetModel(-1));
        }

        public ActionResult DeleteCategory(int groupId)
        {
            var model = new List<ProductsGroup>();
            try
            {
                using (var context = new GasOilEntities())
                {
                    var group = context.ProductsGroups.FirstOrDefault(g => g.id == groupId);

                    context.ProductsGroups.Remove(group);

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
                using (var context = new GasOilEntities())
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
                using (var context = new GasOilEntities())
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
          
                using (var context = new GasOilEntities())
                {
                    model = context.ProductsGroups.ToList();
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
                using (var context = new GasOilEntities())
                {
                    var group = new ProductsGroup {Name = groupName};

                    context.ProductsGroups.Add(group);

                    context.SaveChanges();
                }
            }
            catch
            {
            }

            return View("Index", GetModel(groupId));
        }

        public ActionResult Show(long? groupId)
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
                using (var context = new GasOilEntities())
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
                using (var context = new GasOilEntities())
                {
                    var product = new Product
                                      {
                                          Name = productName,
                                          GroupId = groupId,
                                          UnitOfMeasurementId = unitId
                                      };

                    context.Products.Add(product);

                    context.SaveChanges();
                }
            }
            catch
            {
            }

            return View("Index", GetModel(groupId));
        }

        public ActionResult Edit(long? groupId, long productId)
        {
            ViewBag.groupId = groupId;

            var model = new EditProductsPageModel();
            using (var context = new GasOilEntities())
            {
                var repository = new Repository(context);
                model.Product = repository.GetProductModel(productId);
                model.ProductsGroups = context.ProductsGroups.ToList();
                model.UnitOfMeasurements = context.UnitOfMeasurements.ToList();
            }

            return View("Edit", model);
        }

        public ActionResult Delete(int productId)
        {
            long? groupId = null;
            using (var context = new GasOilEntities())
            {
                var product = context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                    groupId = product.GroupId;

                context.Products.Remove(product);

                context.SaveChanges();
            }

            return View("Index", GetModel(groupId));
        }

        [HttpPost]
        public ActionResult Update(long productId, long? groupId, string productName, long? unitId)
        {
            ViewBag.groupId = groupId;

            using (var context = new GasOilEntities())
            {
                var repository = new Repository(context);

                var product = repository.GetProduct(productId);
                if (product != null)
                {
                    product.Name = productName;
                    product.GroupId = groupId;
                    product.UnitOfMeasurementId = unitId;
                }

                context.SaveChanges();
            }

            return View("Index", GetModel(groupId));
        }
    }
}
