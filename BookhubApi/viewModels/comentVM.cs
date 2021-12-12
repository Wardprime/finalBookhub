using BookhubApi.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookhubApi.viewModels
{
    public class comentVM
    {
        public int ComentsId { get; set; }
        public int UserId { get; set; }
        public int PublicationId { get; set; }
        public string Coment1 { get; set; }
        public DateTime Fecha { get; set; }
    }
}
