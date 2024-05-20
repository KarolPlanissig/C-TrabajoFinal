using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Relacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }

        public override string ToString()
        {
            return Descripcion.ToString(); 
        }
    }
}
