using Alejandria.NotificationService.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.NotificationService.Implementation.Business.EmailManagment.Controllers
{
    [ApiController]
    [Route("/v1/[controller]/[action]")]
    public class EmailManagmentController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail([FromBody] SendEmailRequestDto request)
        {
            return Ok(new SendEmailResponseDto { Sended = false });
        }
    }
}
