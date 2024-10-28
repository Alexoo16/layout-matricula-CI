using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistMatricula.Entidades.Core;
using SistMatricula.LogicaNegocio.Core;

namespace SistMatricula.ClienteWeb.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Aumno
        public ActionResult Index()
        {
            List<AlumnoPosgrado> alumnos = new List<AlumnoPosgrado>();
            alumnos = new AlumnoPosgradoLN().ListaAlumnos();
            return View(alumnos);
        }

        // GET: Aumno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Aumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aumno/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aumno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aumno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aumno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
