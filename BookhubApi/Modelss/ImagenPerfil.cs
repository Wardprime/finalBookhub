using System;
using System.Collections.Generic;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class ImagenPerfil
    {
        public int UserId { get; set; }
        public string Imagen { get; set; }

        public virtual User User { get; set; }
    }
}
