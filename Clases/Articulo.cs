using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Articulo
    {
        public string CodigoArt { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public Relacion Tipo { get; set; }
        public Relacion Marca { get; set; }

        public override string ToString()
        {
            return Tipo.ToString();
        } 


    }
}
