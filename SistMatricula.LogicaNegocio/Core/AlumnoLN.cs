using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistMatricula.AccesoDatos.Core;
using SistMatricula.Entidades.Base;
using SistMatricula.Entidades.Core;

namespace SistMatricula.LogicaNegocio.Core
{
    public class AlumnoLN : BaseLN
    {
        public List<Alumno> ListaAlumnos()
        {
            try
            {
                AlumnoDA alumnoDA = new AlumnoDA();
                return alumnoDA.ListaAlumnos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
