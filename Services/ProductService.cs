using ProductManager.Models;
using Microsoft.EntityFrameworkCore;
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
            var product = context.products?.FirstOrDefault(p => p.productId == productId);
            if (product == null) { throw new KeyNotFoundException("Not found key " + productId); }
            context.products?.Remove(product);
            context.SaveChanges();
        }

        public List<Category>? getAllCategory()
        {
            return context.categories?.ToList();
        }

        public List<Product>? getAllProduct(string sort, string productName, int categoryId)
        {
            if (sort == null && productName == null && categoryId == 0)
            {
                return context.products?.Include(p => p.category).ToList();
            }
            else if (sort == null && productName != null && categoryId == 0)
            {
                return context.products?.Where(p => p.productName.Contains(productName)).Include(p => p.category).ToList();
            }
            else if (sort != null && productName == null && categoryId == 0)
            {
                return (sort.Equals("asc")) ? context.products?.OrderBy(p => p.productName).Include(p => p.category).ToList() : context.products?.OrderByDescending(p => p.productName).Include(p => p.category).ToList();
            }
            else if (sort != null && productName != null && categoryId == 0)
            {
                var products = context.products?.Where(p => p.productName.Contains(productName));
                return (sort.Equals("asc")) ? products?.OrderBy(p => p.productName).Include(p => p.category).ToList() : products?.OrderByDescending(p => p.productName).Include(p => p.category).ToList();
            }
            else if (sort != null && productName == null && categoryId != 0)
            {
                var products = context.products?.Where(p => p.categoryId == categoryId);
                return (sort.Equals("asc")) ? products?.OrderBy(p => p.productName).Include(p => p.category).ToList() : products?.OrderByDescending(p => p.productName).Include(p => p.category).ToList();
            }
            else if (sort == null && productName != null && categoryId != 0)
            {
                return context.products?.Where(p => p.productName.Contains(productName) && p.categoryId == categoryId).Include(p => p.category).ToList();
            }
            else
            {
                var products = context.products?.Where(p => p.productName.Contains(productName) && p.categoryId == categoryId);
                return (sort.Equals("asc")) ? products?.OrderBy(p => p.productName).Include(p => p.category).ToList() : products?.OrderByDescending(p => p.productName).Include(p => p.category).ToList();
            }
        }

        public Product? getProductById(int productId)
        {
            return context.products?.FirstOrDefault(p => p.productId == productId);
        }

        public void insertProduct(Product product)
        {
            context.products?.Add(product);
            context.SaveChanges();
        }

        public void updateProduct(Product product)
        {
            var _product = getProductById(product.productId);
            if (_product == null) { throw new KeyNotFoundException("Not found key " + product.productId); }
            _product = map(_product, product);
            context.products?.Update(_product);
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