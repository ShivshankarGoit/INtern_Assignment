using Microsoft.EntityFrameworkCore;
using myFirstWeb.Models;

namespace myFirstWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Category> Categories { get; set; }
    }
}
