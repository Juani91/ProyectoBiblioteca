using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.LibroContract
{
    public class LibroResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
