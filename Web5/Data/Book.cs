using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Web5.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; } = "";

        public int? PublishYear { get; set; }
        public int PageCount { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; } = "";

        public virtual List<Book> Books { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BookContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bilgisayar" },
                new Category { Id = 2, Name = "Tarih" },
                new Category { Id = 3, Name = "Edebiyat" },
                new Category { Id = 4, Name = "Resim" },
                new Category { Id = 5, Name = "Sağlık" }
                );
        }

    }
}
