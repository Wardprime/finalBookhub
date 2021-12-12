using System;
using System.Collections.Generic;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class Book
    {
        public Book()
        {
            Publications = new HashSet<Publication>();
        }

        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Book1 { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
