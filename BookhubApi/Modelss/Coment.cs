using System;
using System.Collections.Generic;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class Coment
    {
        public int ComentsId { get; set; }
        public int UserId { get; set; }
        public int PublicationId { get; set; }
        public string Coment1 { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Publication Publication { get; set; }
        public virtual User User { get; set; }
    }
}
