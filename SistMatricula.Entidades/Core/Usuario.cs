using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistMatricula.Entidades.Core
{
    public class Usuario
    {
        public int TipoUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string Dni { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public byte[] Contrasena { get; set; }
        public string ContrasenaTexto { get; set; }
        public string Celular { get; set; }
        public string Pais { get; set; }
    }
}
