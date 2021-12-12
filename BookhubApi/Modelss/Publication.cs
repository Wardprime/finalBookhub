using System;
using System.Collections.Generic;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class Publication
    {
        public Publication()
        {
            Coments = new HashSet<Coment>();
        }

        public int PublicationId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Publication1 { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Coment> Coments { get; set; }
    }
}
