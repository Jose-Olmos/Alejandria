using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.BookManagment.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetBooksByTitle(string bookTitle);
    }
}
