using ProyectoNoSQL_Web.Entidades;
using ProyectoNoSQL_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoNoSQL_Web.Controllers
{
    public class InventarioController : Controller
    {
        InventarioModel modelo = new InventarioModel();

        // ------------------------------------------------------

        [HttpGet]
        public ActionResult Index()
        {
            var respuesta = modelo.ConsultarDatosInventario();

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Inventario>());
            }
        }

        // ------------------------------------------------------

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Inventario entidad)
        {
            var respuesta = modelo.NuevoDatosInventario(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Inventario");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // ------------------------------------------------------

        [HttpGet]
        public ActionResult Actualizar(string id)
        {
            var respuesta = modelo.ConsultarUnDato(id);

            if (respuesta.Codigo == 0)
                return View(respuesta.Dato);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new Inventario());
            }
        }

        [HttpPost]
        public ActionResult Actualizar(Inventario entidad)
        {
            var respuesta = modelo.Editar(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Inventario");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        // ------------------------------------------------------

        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            var respuesta = modelo.Eliminar(id);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Inventario");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
    }
}