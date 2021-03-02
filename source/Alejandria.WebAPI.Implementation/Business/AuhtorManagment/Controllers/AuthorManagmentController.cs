using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Services;
using Devon4Net.Infrastructure.Log;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Controllers
{
    [ApiController]
    [Route("/v1/[controller]/[action]")]
    public class AuthorManagmentController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorManagmentController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> Publish([FromQuery] string authorId, [FromBody] PublishBookRequestDto requestDto)
        {
            Devon4NetLogger.Debug("Entering PublishBook on AuthorManagmentController");
            return Ok(await _authorService.PublishBook(Guid.Parse(authorId), requestDto).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequestDto requestDto)
        {
            Devon4NetLogger.Debug("Entering CreateAuthor on AuthorManagmentController");
            return Ok(await _authorService.CreateAuthor(requestDto).ConfigureAwait(false));
        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            Devon4NetLogger.Debug("Entering GetAll on AuthorManagmentController");
            return Ok(await _authorService.GetAuhtors().ConfigureAwait(false));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string authorId)
        {
            Devon4NetLogger.Debug("Entering Delete on AuthorManagmentController");
            return Ok(await _authorService.DeleteAuthor(Guid.Parse(authorId)).ConfigureAwait(false));
        }
    }
}
