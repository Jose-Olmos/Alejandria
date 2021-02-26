using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Alejandria.WebAPI.Implementation.Data.Entities
{
    public partial class AuthorBook
    {
        public Guid Author { get; set; }
        public Guid Book { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ValidityDate { get; set; }

        public virtual Author AuthorNavigation { get; set; }
        public virtual Book BookNavigation { get; set; }
    }
}
