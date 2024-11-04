using EmployeeDetailsEntity.Models.Details;
using EmployeeDetailsEntity.Models.emp;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsEntity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        

        public DbSet<Employee> employees { get; set; }

        public DbSet<EmployeeDetails> employeeDetails { get; set; }
    }
}
