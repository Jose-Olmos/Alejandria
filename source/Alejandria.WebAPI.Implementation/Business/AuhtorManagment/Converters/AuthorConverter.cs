using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Converters
{
    internal static class AuthorConverter
    {
        public static Author ToAuthor(this CreateAuthorRequest request) => new Author
        {
            Email = request.Email,
            Name = request.Name,
            Phone = request.Phone,
            Surname = request.Surname
        };

        public static AuthorResponse ToAuthorResponse(this Author author) => new AuthorResponse
        {
            Id = author.Id,
            Email = author.Email,
            Name = author.Name,
            Phone = author.Phone,
            Surname = author.Surname
        };
    }
}
