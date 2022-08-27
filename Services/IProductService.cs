using ProductManager.Models;
namespace ProductManager.Services

{
    public interface IProductService
    {
        List<Product> getAllProduct();
    }
}