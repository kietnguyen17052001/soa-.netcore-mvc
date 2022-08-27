namespace ProductManager.Models
{
    public class Product
    {
        public List<Product> products = new List<Product>();
        public int productId { get; set; }
        public string productName { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }

        public Product(int productId, string productName, float price, int quantity)
        {
            this.productId = productId;
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
        }
        public Product()
        {
            products.Add(new Product(1, "thinkpad", 12.0F, 10));
            products.Add(new Product(1, "dell", 11.0F, 12));
            products.Add(new Product(1, "macbook", 14.0F, 11));
            products.Add(new Product(1, "asus", 13.0F, 13));
        }
    }
}