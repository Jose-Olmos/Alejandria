using Alejandria.WebAPI.Implementation.Data.Entities;
using Devon4Net.Domain.UnitOfWork.Repository;
using System;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces
{
    public interface IAuthorRepository : IRepository<Author>  { }
}
