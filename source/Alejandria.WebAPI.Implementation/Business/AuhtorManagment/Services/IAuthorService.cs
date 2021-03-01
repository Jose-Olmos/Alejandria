using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Services
{
    public interface IAuthorService
    {
        Task<BookResponse> PublishBook(Guid authorId, PublishBookRequest request);
        Task<bool> DeleteAuthor(Guid authorId);
        Task<AuthorResponse> CreateAuthor(CreateAuthorRequest request);
        Task<IEnumerable<AuthorResponse>> GetAuhtors();
    }
}
