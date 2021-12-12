using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookhubApi.viewModels
{
    public class userVM
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Correo { get; set; }
        public string Contra { get; set; }
        public DateTime Fecha { get; set; }
    }
}
