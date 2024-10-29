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
    public class OpcionLN : BaseLN
    {
        public List<Opcion> ListaOpcionesAlumno()
        {
            List<Opcion> opciones = new List<Opcion>();
            try
            {
                OpcionDA opcionDA = new OpcionDA();
                opciones = opcionDA.ListaOpcionesAlumno();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return opciones;
        }
        public List<Opcion> ListaOpcionesAC()
        {
            List<Opcion> opciones = new List<Opcion>();
            try
            {
                OpcionDA opcionDA = new OpcionDA();
                opciones = opcionDA.ListaOpcionesAC();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return opciones;
        }
        public List<Opcion> ListaOpcionesAAP() {
            List<Opcion> opciones = new List<Opcion>();
            try
            {
                OpcionDA opcionDA = new OpcionDA();
                opciones = opcionDA.ListaOpcionesAAP();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return opciones;
        }
        public List<Opcion> ListaOpcionesCoord()
        {
            List<Opcion> opciones = new List<Opcion>();
            try
            {
                OpcionDA opcionDA = new OpcionDA();
                opciones = opcionDA.ListaOpcionCoord();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return opciones;
        }
    }
}
