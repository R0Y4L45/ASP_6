using Asp_5.Entities;
using Asp_5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp_5.Controllers;

public class ProductController : Controller
{
    private ProductViewModel? pvm;

    private static List<Product> products = new List<Product>()
    {
        new Product()
        {
            Name = "Potato",
            Price = 1.2M,
            Count = 40,
            Description = "Made in Gadabay"
        },
        new Product()
        {
            Name = "Tomato",
            Price = 1.5M,
            Count = 50,
            Description = "Made in Zira"
        },
        new Product()
        {
            Name = "Cucumber",
            Price = 1.2M,
            Count = 20,
            Description = "Made in Ganja"
        },
    };

    public ProductController()
    {
        pvm = new ProductViewModel()
        {
            Products = products
        };
    }

    #region Action Methods

    public IActionResult Get()
    {
        return View(pvm);
    }
    public IActionResult Delete(int id)
    {
        products.Remove(products.First(x => x.Id == id));
        return RedirectToAction("Get");
    }
    public IActionResult Add()
    {
        return View(pvm);
    }

    [HttpPost]
    public IActionResult Add(ProductViewModel pvm)
    {
        if (ModelState.IsValid)
        {
            products.Add(pvm.Product!);
            return RedirectToAction("Get");
        }
        return View();
    }

    public IActionResult SearchView(ProductViewModel pvm)
    {
        pvm.Products = products.Where(x => x.Name!.ToLower() == pvm.Search.ToLower()).ToList();
        return View(pvm);
    }

    [HttpPost]
    public IActionResult Search(ProductViewModel pvm)
    {
        if (pvm.Search != null && pvm.Search != string.Empty)
            return RedirectToAction("SearchView", pvm);
        return RedirectToAction("get");
    }

    #endregion
}
