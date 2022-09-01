using Microsoft.EntityFrameworkCore;

namespace ProductManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p => p.category)
            .WithMany(c => c.products)
            .HasForeignKey(p => p.categoryId);


            base.OnModelCreating(modelBuilder);
        }
    }
}