using Devon4Net.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Exceptions
{
    /// <summary>
    /// Custom exception AuthorNotFoundException
    /// </summary>
    [Serializable]
    public class AuthorNotFoundException : Exception, IWebApiException
    {
        /// <summary>
        /// The forced http status code to be fired on the exception manager
        /// </summary>
        public int StatusCode => StatusCodes.Status404NotFound;

        /// <summary>
        /// Show the message on the response
        /// </summary>
        public bool ShowMessage => true;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorNotFoundException"/> class.
        /// </summary>
        public AuthorNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AuthorNotFoundException(string message)
            : base(message)
        {
        }
    }
}
