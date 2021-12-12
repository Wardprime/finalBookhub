using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookhubApi.viewModels
{
    public class bookVM
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Book1 { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
