using System;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Exceptions
{
    class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException() { }
        public AuthorNotFoundException(string message): base(message) { }
    }
}
