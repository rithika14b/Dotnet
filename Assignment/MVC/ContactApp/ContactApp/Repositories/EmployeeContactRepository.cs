using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MvcAsyncDemo.Models;

namespace MvcAsyncDemo.Repositories
{
    public class EmployeeContactRepository : IEmployeeContactRepository
    {
        private readonly EmployeeDbContext db;

        public EmployeeContactRepository()
        {
            db = new EmployeeDbContext();
        }

        public async Task<List<EmployeeContact>> GetAllAsync()
        {
            return await db.EmployeeContacts.ToListAsync();
        }

        public async Task AddAsync(EmployeeContact employee)
        {
            db.EmployeeContacts.Add(employee);

            await db.SaveChangesAsync();
        }

        public async Task RemoveAsync(long id)
        {
            var data = await db.EmployeeContacts.FindAsync(id);

            if (data != null)
            {
                db.EmployeeContacts.Remove(data);

                await db.SaveChangesAsync();
            }
        }
    }
}