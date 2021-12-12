using System;
using System.Collections.Generic;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
            Coments = new HashSet<Coment>();
            Publications = new HashSet<Publication>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Correo { get; set; }
        public string Contra { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Coment> Coments { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
