using System.Collections.Generic;
using System.Threading.Tasks;
using MvcAsyncDemo.Models;

namespace MvcAsyncDemo.Repositories
{
    public interface IEmployeeContactRepository
    {
        Task<List<EmployeeContact>> GetAllAsync();

        Task AddAsync(EmployeeContact employee);

        Task RemoveAsync(long id);
    }
}