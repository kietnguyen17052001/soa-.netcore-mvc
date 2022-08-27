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

}
