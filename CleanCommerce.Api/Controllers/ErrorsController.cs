using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error()
        {
            //get error from context
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = context?.Error;

            //Warning: should not return exception details in production
            //return Problem(detail: ex?.Message);

            return Problem();
        }
    }

}
