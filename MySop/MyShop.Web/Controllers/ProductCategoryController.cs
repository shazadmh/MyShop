using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myShop.Core.Models;
using MyShop.DataAccessInMemory;

namespace MyShop.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryRepository context;

        public ProductCategoryController()
        {
            context = new  ProductCategoryRepository();
        }
        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> ProductCategorys = context.Collection().ToList();
            return View(ProductCategorys);
        }

        public ActionResult Create()
        {
            ProductCategory ProductCategory = new ProductCategory();
            return View(ProductCategory);

        }

        [HttpPost]
        public ActionResult Create(ProductCategory ProductCategory)
        {
            if (!ModelState.IsValid)
            {

                return View(ProductCategory);

            }
            else
            {
                context.Insert(ProductCategory);
                context.Commit();

                return RedirectToAction("Index");
            }


        }

        public ActionResult Edit(string Id)
        {
            ProductCategory ProductCategory = context.Find(Id);

            if (ProductCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductCategory);
            }

        }

        [HttpPost]
        public ActionResult Edit(ProductCategory ProductCategory, string Id)
        {
            ProductCategory ProductCategoryToEdit = context.Find(Id);

            if (ProductCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(ProductCategory);
                }
                else
                {
                    ProductCategoryToEdit.Category = ProductCategory.Category;
                    ProductCategoryToEdit.Id = Id;


                    context.Commit();

                    return RedirectToAction("Index");
                }


            }

        }

        public ActionResult Delete(string Id)
        {
            ProductCategory ProductCategoryToDelete = context.Find(Id);

            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductCategoryToDelete);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory ProductCategoryToDelete = context.Find(Id);

            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}