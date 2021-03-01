using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Business.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Services
{
    public interface IAuthorService
    {
        Task<BookResponseDto> PublishBook(Guid authorId, PublishBookRequestDto request);
        Task<bool> DeleteAuthor(Guid authorId);
        Task<AuthorResponseDto> CreateAuthor(CreateAuthorRequestDto request);
        Task<IEnumerable<AuthorResponseDto>> GetAuhtors();
    }
}
