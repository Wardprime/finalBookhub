using BookhubApi.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookhubApi.viewModels
{
    public class publicationVM
    {
        public int PublicationId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Publication1 { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
