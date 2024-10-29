using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistMatricula.AccesoDatos.Core;
using SistMatricula.Entidades.Core;

namespace SistMatricula.LogicaNegocio.Core
{
    public class AsistenteAtencionLN
    {
        public AsistenteAtencionPublico BuscarAsistenteAtencionPublico(Usuario asistenteAtencionPublico)
        {
            try
            {
                AsistenteAtencionDA asistenteAtencionPublicoDA = new AsistenteAtencionDA();
                return asistenteAtencionPublicoDA.BuscarAsistenteAtencionPublico(asistenteAtencionPublico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
