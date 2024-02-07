using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project4_2;

public class ProductController : Controller
{
    private List<Product> products = new List<Product>
    {
        new Product { Id = 1, Code = "P001", Name = "Product 1", ReleaseDate = DateTime.Now.AddDays(-5) },
        new Product { Id = 2, Code = "P002", Name = "Product 2", ReleaseDate = DateTime.Now.AddDays(-10) }
    };

    public ActionResult Index()
    {
        return View(products);
    }

    public ActionResult AddEditProduct(int? id)
    {
        var product = id.HasValue ? products.FirstOrDefault(p => p.Id == id.Value) : new Product();
        return View(product);
    }

    [HttpPost]
    public ActionResult AddEditProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            if (product.Id == 0)
            {
                // Add new product
                product.Id = products.Count + 1;
                products.Add(product);
            }
            else
            {
                // Update existing product
                var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Code = product.Code;
                    existingProduct.Name = product.Name;
                    existingProduct.ReleaseDate = product.ReleaseDate;
                }
            }

            return RedirectToAction("Index");
        }

        return View(product);
    }

    public ActionResult DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        return View(product);
    }

    [HttpPost]
    public ActionResult ConfirmDelete(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
        }

        return RedirectToAction("Index");
    }
}