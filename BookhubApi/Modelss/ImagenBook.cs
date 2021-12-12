using System;
using System.Collections.Generic;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class ImagenBook
    {
        public int BookId { get; set; }
        public string Imagen { get; set; }

        public virtual Book Book { get; set; }
    }
}
