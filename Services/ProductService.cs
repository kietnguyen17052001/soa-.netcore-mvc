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

        public void deleteProduct(int productId)
        {
            var product = context.products.FirstOrDefault(p => p.productId == productId);
            if (product == null) { throw new KeyNotFoundException("Not found key " + productId); }
            context.products.Remove(product);
            context.SaveChanges();
        }

        public List<Category> getAllCategory()
        {
            return context.categories.ToList();
        }

        public List<Product> getAllProduct()
        {
            return context.products.ToList();
        }

        public List<Product> searchProduct(string search)
        {
            return context.products.ToList().Where(p => p.productName.Contains(search)).ToList();
        }

        public Product? getProductById(int productId)
        {
            return context.products.FirstOrDefault(p => p.productId == productId);
        }

        public void insertProduct(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
        }

        public void updateProduct(Product product)
        {
            var _product = getProductById(product.productId);
            if (_product == null) { throw new KeyNotFoundException("Not found key " + product.productId); }
            _product = map(_product, product);
            context.products.Update(_product);
            context.SaveChanges();
        }

        public Product map(Product product, Product requestProduct)
        {
            product.productName = requestProduct.productName;
            product.quantity = requestProduct.quantity;
            product.slug = requestProduct.slug;
            product.price = requestProduct.price;
            product.categoryId = requestProduct.categoryId;
            return product;
        }
    }
}