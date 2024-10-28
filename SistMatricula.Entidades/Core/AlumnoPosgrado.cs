using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistMatricula.Entidades.Core
{
    public class AlumnoPosgrado : Usuario
    {
        public int IdAlumno { get; set; }
        public string facultad { get; set; }
        public string profesion { get; set; }
        public string grado { get; set; }
        public bool egresadoLocal { get; set; }
    }
}
