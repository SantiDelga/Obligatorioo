using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio.Clases
{
    public class OrdenDeTrabajo
    {
        public int NumeroOrden { get; set; }
        public string Cliente { get; set; }
        public string Tecnico { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public List<string> ComentariosTecnico { get; set; }
    }
}