using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;
namespace ProductManager.Controllers;

public class ProductController : Controller
{
    private readonly IProductService service;
    public ProductController(IProductService service)
    {
        this.service = service;
    }

    public IActionResult Index()
    {
        var products = service.getAllProduct();
        return View(products);
    }
    public IActionResult Save(Product product)
    {
        if (service.getProductById(product.productId) == null)
        {
            service.insertProduct(product);
        }
        else
        {
            service.updateProduct(product);
        }
        return Redirect("Index");
    }
    public IActionResult Create()
    {
        var categories = service.getAllCategory();
        return View(categories);
    }

    public IActionResult Update(int productId)
    {
        var product = service.getProductById(productId);
        if (product == null) return Redirect("Index");
        var categories = service.getAllCategory();
        ViewBag.Product = product;
        return View(categories);
    }
    public IActionResult Delete(int productId)
    {
        service.deleteProduct(productId);
        return RedirectToAction("Index");
    }

}
