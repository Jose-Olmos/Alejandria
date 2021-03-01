using Alejandria.WebAPI.Implementation.Business.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.BookManagment.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetBooksByTitle(string bookTitle);
    }
}
