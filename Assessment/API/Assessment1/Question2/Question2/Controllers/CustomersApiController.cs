using Question2;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Question2.Models;

namespace Question2.Controllers
{
    public class CustomersApiController : ApiController
    {
        northwindEntities1 db = new northwindEntities1();

        // GET: api/customersapi/bycountry?country=USA
        [HttpGet]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var result = db.Database.SqlQuery<Customer>(
                "exec GetCustomersByCountry @Country",
                new SqlParameter("@Country", country)
            ).ToList();

            return Ok(result);
        }
    }
}