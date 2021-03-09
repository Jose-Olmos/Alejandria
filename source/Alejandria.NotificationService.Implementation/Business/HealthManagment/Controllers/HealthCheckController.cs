using Microsoft.AspNetCore.Mvc;

namespace Alejandria.NotificationService.Implementation.Business.HealthManagment.Controllers
{
    [ApiController]
    [Route("/v1/[controller]/[action]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
