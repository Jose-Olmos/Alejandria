using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Data.Entities;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Converters
{
    internal static class AuthorConverter
    {
        public static Author ToAuthor(this CreateAuthorRequestDto request) => new Author
        {
            Email = request.Email,
            Name = request.Name,
            Phone = request.Phone,
            Surname = request.Surname
        };

        public static AuthorResponseDto ToAuthorResponse(this Author author) => new AuthorResponseDto
        {
            Id = author.Id,
            Email = author.Email,
            Name = author.Name,
            Phone = author.Phone,
            Surname = author.Surname
        };
    }
}
