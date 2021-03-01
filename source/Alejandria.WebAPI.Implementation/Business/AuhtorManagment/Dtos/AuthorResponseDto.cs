using System;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos
{
    public class AuthorResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
