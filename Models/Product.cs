
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductManager.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int productId { get; set; }
        [MaxLength(256)]
        public string? productName { get; set; }
        [MaxLength(256)]
        public string? slug { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public int quantity { get; set; }
        public int categoryId { get; set; }
        public Category? category { get; set; }
    }
}