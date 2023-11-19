using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class OrdersController : ApiController
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(new string[] { "caio", "mario"});
        }
    }
}
