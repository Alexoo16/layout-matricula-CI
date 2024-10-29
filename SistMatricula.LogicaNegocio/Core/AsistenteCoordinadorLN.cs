using SistMatricula.AccesoDatos.Core;
using SistMatricula.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistMatricula.LogicaNegocio.Core
{
    public class AsistenteCoordinadorLN
    {
        public AsistenteCoordinacion BuscarAsistenteCoordinador(Usuario asistenteCoordinacion)
        {
            try
            {
                AsistenteCoordinadorDA asistenteCoordinadorDA = new AsistenteCoordinadorDA();
                return asistenteCoordinadorDA.BuscarAsistenteCoordinador(asistenteCoordinacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}