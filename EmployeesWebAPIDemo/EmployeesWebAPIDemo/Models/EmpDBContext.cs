using Microsoft.EntityFrameworkCore;

namespace EmployeesWebAPIDemo.Models
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions<EmpDBContext> dbContextOptions)
            :base(dbContextOptions)
        { 
            
        }

        public virtual DbSet<Employee> tbl_employees { get; set; }
    }
}
