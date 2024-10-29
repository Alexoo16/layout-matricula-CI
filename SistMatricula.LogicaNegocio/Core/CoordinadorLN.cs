using SistMatricula.AccesoDatos.Core;
using SistMatricula.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistMatricula.LogicaNegocio.Core
{
    public class CoordinadorLN
    {
        public Coordinador BuscarCoordinador(Usuario coordinador)
        {
          
            try
            {
                CoordinadorDA coordinadoDA = new CoordinadorDA();
                return coordinadoDA.BuscarCoordinador(coordinador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}