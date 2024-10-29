using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using SistMatricula.Entidades;
using SistMatricula.Entidades.Core;
using SistMatricula.LogicaNegocio.Core;
using SistMatricula.Utiles.Helpers;
using SistMatricula.Entidades.Base;

namespace SistMatricula.ClienteWeb.Controllers
{
    public class LoginController : BaseLN
    {
        // GET: Login
        public ActionResult Index()
        {
            Usuario u = new Usuario();
            return View(u);
        }
        [HttpPost]
        public ActionResult Index(Usuario usuario, int TipoUsuario)
        {
            if (string.IsNullOrEmpty(usuario.Dni) ||
            string.IsNullOrEmpty(usuario.ContrasenaTexto))
            {
                //Log.Info("Llego usuario: " + usuario.CodUsuario);
                ModelState.AddModelError("*", "Debe llenar el usuario o clave");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Contrasena = EncriptacionHelper.EncriptarByte(usuario.ContrasenaTexto);
                    // Convierte la contraseña en un string hexadecimal con el formato deseado
                    string contrasenaHex = "0x" + BitConverter.ToString(usuario.Contrasena).Replace("-", "").PadRight(128, '0');

                    // Muestra en el Output de Visual Studio
                    System.Diagnostics.Debug.WriteLine("Texto original: " + usuario.ContrasenaTexto);
                    System.Diagnostics.Debug.WriteLine("Texto encriptado (hex): " + contrasenaHex);

                    Usuario res = null;
                    switch (TipoUsuario)
                    {
                        case 1:
                            res = new AsistenteCoordinadorLN().BuscarAsistenteCoordinador(usuario);
                            break;
                        case 2:
                            res=new CoordinadorLN().BuscarCoordinador(usuario);
                            break;
                        case 3:
                            res=new AlumnoPosgradoLN().BuscarAlumnoPosgrado(usuario);
                            break;
                        case 4:
                            res=new AsistenteAtencionLN().BuscarAsistenteAtencionPublico(usuario);
                            break;
                    }
                    if (res != null && res.Id > 0)
                    { //las credenciales son correctas
                        //Llenar una cookie
                        FormsAuthentication.SetAuthCookie(res.Dni, true);
                        //llenar una sesion
                        List<Opcion> lista = null;
                        switch(TipoUsuario){
                            case 1:
                                lista = new OpcionLN().ListaOpcionesAC();
                                break;
                            case 2:
                                lista = new OpcionLN().ListaOpcionesCoord();
                                break;
                            case 3:
                                lista = new OpcionLN().ListaOpcionesAlumno();
                                break;
                            case 4:
                                lista = new OpcionLN().ListaOpcionesAAP();
                                break;
                        }
                        //para separar los controles de las acciones en la tabla de Opciones.
                        ParsearAcciones(lista);
                        VariablesWeb.gOpciones = lista;
                        Log.Info("Llego las opciones. " + VariablesWeb.gOpciones.Count().ToString());
                        VariablesWeb.gUsuario = res;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("*", "Usuario / Clave no validos");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("*", ex.Message);
                }
            }
            return View(usuario);
        }
        [NonAction]
        private void ParsearAcciones(List<Opcion> lista)
        {
            int cantidad = 0;
            foreach (Opcion item in lista)
            {
                if (!string.IsNullOrEmpty(item.UrlOpcion))
                {
                    cantidad = item.UrlOpcion.Split('/').Count();
                    switch (cantidad)
                    {
                        case 3:
                            item.Area = item.UrlOpcion.Split('/')[0];
                            item.Controladora = item.UrlOpcion.Split('/')[1];
                            item.Accion = item.UrlOpcion.Split('/')[2];
                            break;
                        case 2:
                            item.Controladora = item.UrlOpcion.Split('/')[0];
                            item.Accion = item.UrlOpcion.Split('/')[1];
                            break;
                        case 1:
                            item.Controladora = item.UrlOpcion.Split('/')[0];
                            item.Accion = "Index";
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}

