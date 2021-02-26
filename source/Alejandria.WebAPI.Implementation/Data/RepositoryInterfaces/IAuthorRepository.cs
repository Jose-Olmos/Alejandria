using Alejandria.WebAPI.Implementation.Data.Entities;
using Devon4Net.Domain.UnitOfWork.Repository;
using System;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces
{
    interface IAuthorRepository : IRepository<Author> 
    {
        Task<Author> GetAuthorAndBooksById(Guid authorId);
    }
}
