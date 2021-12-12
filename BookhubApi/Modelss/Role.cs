using System;
using System.Collections.Generic;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class Role
    {
        public int UserId { get; set; }
        public string Role1 { get; set; }
        public DateTime Fecha { get; set; }

        public virtual User User { get; set; }
    }
}
