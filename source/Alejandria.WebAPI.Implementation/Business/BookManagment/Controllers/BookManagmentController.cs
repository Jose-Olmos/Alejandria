using Alejandria.WebAPI.Implementation.Business.BookManagment.Services;
using Devon4Net.Infrastructure.Log;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.BookManagment.Controllers
{
    [ApiController]
    [Route("/v1/[controller]/[action]")]
    public class BookManagmentController : ControllerBase
    {
        private IBookService _bookService;

        public BookManagmentController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> BooksByTitle(string bookTitle)
        {
            Devon4NetLogger.Debug("Entering Ping method on BookManagmentController");
            return Ok(await _bookService.GetBooksByTitle(bookTitle).ConfigureAwait(false));
        }
    }
}
