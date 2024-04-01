using ProyectoNoSQL_Web.Entidades;
using ProyectoNoSQL_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProyectoNoSQL_Web.Controllers
{
    public class ClientesController : Controller
    {
        ClientesModel modelo = new ClientesModel();
        [HttpGet]
        public ActionResult Index()
        {
            var respuesta = modelo.ConsultarDatosPersonales();

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Cliente>());
            }
        }
        [HttpGet]
        public ActionResult Nuevo()
        {

            var datosPersonales = new Cliente();

            datosPersonales.FechaInicioMembresia = DateTime.Now;

            return View(datosPersonales);
        }

        [HttpPost]
        public ActionResult Nuevo(Cliente entidad)
        {

            var respuesta = modelo.NuevoDatosPersonales(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Clientes");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Actualizar(string id)
        {
            var respuesta = modelo.ConsultarUnDato(id);

            if (respuesta.Codigo == 0)
                return View(respuesta.Dato);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new Cliente());
            }
        }


        [HttpPost]
        public ActionResult Actualizar(Cliente entidad)
        {
            var respuesta = modelo.Editar(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Clientes");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string id)
        {

            var entidad = new Cliente { Id = id };

            var respuesta = modelo.Eliminar(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Clientes");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
    }
}