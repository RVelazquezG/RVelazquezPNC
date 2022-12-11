using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Autor
    {
        [DisplayName("Autor")]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public List<object> Autores { get; set; }
    }
}
