using System;

namespace Alejandria.WebAPI.Implementation.Business.Common.Dtos
{
    public class BookResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Genre { get; set; }
    }
}
