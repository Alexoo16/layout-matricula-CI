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
    public class AlumnoPosgradoLN : BaseLN
    {
        /*
        public List<AlumnoPosgrado> ListaAlumnos()
        {
            try
            {
                AlumnoPosgradoDA alumnoDA = new AlumnoPosgradoDA();
                return alumnoDA.ListaAlumnos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public AlumnoPosgrado BuscarAlumnoPosgrado(Usuario alumno)
        {
            try
            {
                AlumnoPosgradoDA alumnoDA = new AlumnoPosgradoDA();
                return alumnoDA.BuscarAlumnoPosgrado(alumno);
            } catch(Exception ex) {
                throw ex;
            }
        }
    }
}
