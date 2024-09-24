using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario03.Modelos
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string image { get; set; }
    }
}
