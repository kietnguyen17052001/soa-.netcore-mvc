using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductManager.Models
{
    [Table("category")]
    public class Category
    {
        public Category()
        {
            products = new List<Product>();
        }
        [Key]
        public int categoryId { get; set; }
        [MaxLength(256)]
        public string? categoryName { get; set; }
        public List<Product>? products { get; set; }

    }
}
