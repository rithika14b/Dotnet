using System.Data.Entity;

namespace MvcAsyncDemo.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<EmployeeContact> EmployeeContacts { get; set; }
    }
}