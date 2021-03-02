using Alejandria.WebAPI.Implementation.Data.Database;
using Alejandria.WebAPI.Implementation.Data.Entities;
using Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.WebAPI.Implementation.Domain
{
    public class AuthorBookRepository : Repository<AuthorBook>, IAuthorBookRepository
    {
        public AuthorBookRepository(AlejandriaContext context): base(context, true) { }
    }
}
