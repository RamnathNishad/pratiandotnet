using Microsoft.EntityFrameworkCore;

namespace WebAPI_EFCodeFirst.Models
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

    }
}
