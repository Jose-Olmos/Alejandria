using Alejandria.WebAPI.Implementation.Business.Common.Converters;
using Alejandria.WebAPI.Implementation.Business.Common.Dtos;
using Alejandria.WebAPI.Implementation.Data.Database;
using Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Log;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.BookManagment.Services
{
    public class BookService : Service<AlejandriaContext>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IUnitOfWork<AlejandriaContext> unitOfWork) : base(unitOfWork)
        {
            _bookRepository = UoW.Repository<IBookRepository>();
        }

        public async Task<IEnumerable<BookResponseDto>> GetBooksByTitle(string bookTitle)
        {
            Devon4NetLogger.Debug($"Entering GetBooksByTitle on BookService with title : {bookTitle}");
            
            var books = await _bookRepository.Get(book => book.Title == bookTitle).ConfigureAwait(false);
            return books.Select(book => book.ToBookResponse());
        }
    }
}
