using Microsoft.EntityFrameworkCore;
using WebApplication.Entity;

namespace WebApplication.Infra
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
