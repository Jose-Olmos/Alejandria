using Alejandria.WebAPI.Implementation.Data.Database;
using Alejandria.WebAPI.Implementation.Data.Entities;
using Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Repository;

namespace Alejandria.WebAPI.Implementation.Domain
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AlejandriaContext context): base(context, true) { }
    }
}
