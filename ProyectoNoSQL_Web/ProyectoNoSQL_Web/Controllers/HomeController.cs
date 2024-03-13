using ProyectoNoSQL_Web.Entidades;
using ProyectoNoSQL_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoNoSQL_Web.Controllers
{
    public class HomeController : Controller
    {

        DatosPersonalesModel modelo = new DatosPersonalesModel();
        [HttpGet]
        public ActionResult Index()
        {
            var respuesta = modelo.ConsultarDatosPersonales();

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<DatosPersonales>());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Nuevo()
        {

            var datosPersonales = new DatosPersonales();

            datosPersonales.Fecha = DateTime.Now;

            return View(datosPersonales);
        }

        [HttpPost]
        public ActionResult Nuevo(DatosPersonales datosPersonales)
        {

            var respuesta = modelo.NuevoDatosPersonales(datosPersonales);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult MostrarUno(string id)
        {
            var respuesta = modelo.ConsultarUnDato(id);

            if (respuesta.Codigo == 0)
                return View(respuesta.Dato); 
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new DatosPersonales()); 
            }
        }


        [HttpPost]
        public ActionResult MostrarUno(DatosPersonales entidad)
        {
            var respuesta = modelo.Editar(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string id)
        {
            
            var entidad = new DatosPersonales { Id = id };

            var respuesta = modelo.Eliminar(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }


    }
}