using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistMatricula.Entidades.Core
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Dni { get; set; }
    }
}
