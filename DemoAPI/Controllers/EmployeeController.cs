using DemoAPI.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    [RoutePrefix("api/v1")]
    public class EmployeeController : ApiController
    {
        private List<Employee> Employees { get; set; }

        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello!");
        }
    }
}
