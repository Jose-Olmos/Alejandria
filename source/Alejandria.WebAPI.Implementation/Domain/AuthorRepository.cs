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
    }
}
