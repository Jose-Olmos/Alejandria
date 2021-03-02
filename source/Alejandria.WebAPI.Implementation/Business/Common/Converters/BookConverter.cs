using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Business.Common.Dtos;
using Alejandria.WebAPI.Implementation.Data.Entities;
using System;

namespace Alejandria.WebAPI.Implementation.Business.Common.Converters
{
    internal static class BookConverter
    {
        public static Book ToBook(this PublishBookRequestDto request) => new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Genre = request.Genre,
            Summary = request.Summary
        };

        public static BookResponseDto ToBookResponse(this Book book) => new BookResponseDto
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            Summary = book.Summary
        };
    }
}
