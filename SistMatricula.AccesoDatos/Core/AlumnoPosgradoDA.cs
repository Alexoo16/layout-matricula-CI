using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistMatricula.Entidades.Core;

namespace SistMatricula.AccesoDatos.Core
{
    public class AlumnoPosgradoDA
    {
        public List<AlumnoPosgrado> ListaAlumnos()
        {
            try
            {
                List<AlumnoPosgrado> alumnos = new List<AlumnoPosgrado>();
                alumnos.Add(new AlumnoPosgrado { IdAlumno = 1, Nombres = "Juan", ApellidoPat = "Perez", ApellidoMat = "Gomez", Dni = "12345678" });
                alumnos.Add(new AlumnoPosgrado { IdAlumno = 2, Nombres = "Maria", ApellidoPat = "Garcia", ApellidoMat = "Perez", Dni = "87654321" });
                alumnos.Add(new AlumnoPosgrado { IdAlumno = 3, Nombres = "Pedro", ApellidoPat = "Torres", ApellidoMat = "Gomez", Dni = "45678912" });

                return alumnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
