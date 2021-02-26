using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Alejandria.WebAPI.Implementation.Data.Entities
{
    public partial class Book
    {
        public Book()
        {
            AuthorBook = new HashSet<AuthorBook>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<AuthorBook> AuthorBook { get; set; }
    }
}
