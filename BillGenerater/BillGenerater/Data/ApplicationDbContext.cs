namespace BillGenerater.Data
{
    public class ApplicationDbContext :  IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>) { }
    }
    public DbSet<Customer> Customers {  get; set; }
    public DbSet<Item> Item {  get; set; }
}
