using Devon4Net.Infrastructure.Log;
using Microsoft.AspNetCore.Mvc;

namespace Alejandria.WebAPI.Implementation.Business.BookManagment.Controllers
{
    [ApiController]
    [Route("/v1/[controller]/[action]")]
    public class BookManagmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            Devon4NetLogger.Debug("Entering Ping method on BookManagmentController");
            return Ok();
        }
    }
}
