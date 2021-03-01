using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Genre { get; set; }
    }
}
