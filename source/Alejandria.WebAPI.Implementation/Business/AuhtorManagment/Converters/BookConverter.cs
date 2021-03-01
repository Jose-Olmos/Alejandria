using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Converters
{
    internal static class BookConverter
    {
        public static Book ToBook(this PublishBookRequest request) => new Book
        {
            Title = request.Title,
            Genre = request.Genre,
            Summary = request.Summary
        };

        public static BookResponse ToBookResponse(this Book book) => new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            Summary = book.Summary
        };
    }
}
