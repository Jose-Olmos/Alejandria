using Alejandria.WebAPI.Implementation.Data.Database;
using Alejandria.WebAPI.Implementation.Data.Entities;
using Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Domain
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(AlejandriaContext context) : base(context, true)  { }

        public async Task<Author> GetAuthorAndBooksById(Guid authorId)
        {
            var includeFields = new [] { nameof(Author.AuthorBook) };
            var authors = await Get(includeFields, author => author.Id == authorId).ConfigureAwait(false);

            return authors.FirstOrDefault();
        }
    }
}
