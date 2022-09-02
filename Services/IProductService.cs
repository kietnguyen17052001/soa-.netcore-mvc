using ProductManager.Models;
namespace ProductManager.Services

{
    public interface IProductService
    {
        List<Product>? getAllProduct(string sort, string productName, int categoryId);
        Product? getProductById(int productId);
        void insertProduct(Product product);
        void updateProduct(Product product);
        void deleteProduct(int productId);
        List<Category>? getAllCategory();
    }
}