using System.Linq;
using System.Web.Http;
using Question2;
using Question2.Models;  

namespace Question2.Controllers
{
    public class OrdersApiController : ApiController
    {
        northwindEntities1 db = new northwindEntities1();

        [HttpGet]
        public IHttpActionResult GetBuchananStevenOrders()
        {
            var result = (from o in db.Orders
                          join e in db.Employees on o.EmployeeID equals e.EmployeeID
                          where e.EmployeeID == 5
                          select new
                          {
                              o.OrderID,
                              o.OrderDate,
                              o.ShipCity,
                              e.FirstName,
                              e.LastName
                          }).ToList();

            return Ok(result);
        }
    }
}