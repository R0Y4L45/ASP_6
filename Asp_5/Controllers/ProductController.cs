using Asp_5.Entities;
using Asp_5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp_5.Controllers;

public class ProductController : Controller
{
    private PViewModel? _pvm = new PViewModel();
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

    #region Action Methods
    public ProductController()
    {
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductViewModel>());
        Mapper mapper = new Mapper(config);

        _pvm.Products = new List<ProductViewModel>();

        foreach (Product product in products)
            _pvm.Products.Add(mapper?.Map<Product, ProductViewModel>(product) ?? new ProductViewModel());
    }

    public IActionResult Get() => 
        View(_pvm);
    public IActionResult Delete(string name)
    {
        products.Remove(products.First(x => x.Name == name));
        return RedirectToAction("Get");
    }
    public IActionResult Add() => 
        View(new ProductViewModel());

    [HttpPost]
    public IActionResult Add(ProductViewModel pvm)
    {
        if (ModelState.IsValid)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, Product>());
            Mapper mapper = new Mapper(config);

            products.Add(mapper?.Map<Product>(pvm) ?? new Product() { Name = "null", Description = "null" });

            return RedirectToAction("Get");
        }
        return View();
    }

    public IActionResult SearchView(PViewModel pvm)
    {
        pvm.Products = _pvm?.Products?.Where(x => x.Name!.ToLower() == pvm?.SearchResult?.ToLower()).ToList();
        return View(pvm);
    }

    [HttpPost]
    public IActionResult Search(PViewModel pvm)
    {
        if (pvm.SearchResult != null && pvm.SearchResult != string.Empty)
            return RedirectToAction("SearchView", pvm);
        return RedirectToAction("get");
    }

    #endregion
}
