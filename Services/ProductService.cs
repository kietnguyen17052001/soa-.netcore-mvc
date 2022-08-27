using ProductManager.Models;
namespace ProductManager.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext context;
        public ProductService(DataContext context)
        {
            this.context = context;
        }
        public List<Product> getAllProduct()
        {
            return context.products.ToList();
        }
    }
}