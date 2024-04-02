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
    public class RolController : Controller
    {
        RolModel modelo = new RolModel();
        [HttpGet]
        public ActionResult ConsultarRoles()
        {
            var respuesta = modelo.ConsultarRoles();

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Rol>());
            }
        }
        [HttpGet]
        public ActionResult NuevoRol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoRol(Rol entidad)
        {

            var respuesta = modelo.NuevoRol(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("ConsultarRoles", "Rol");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarRol(string id)
        {
            var respuesta = modelo.ConsultarUnDato(id);

            if (respuesta.Codigo == 0)
                return View(respuesta.Dato);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new Rol());
            }
        }


        [HttpPost]
        public ActionResult ActualizarRol(Rol entidad)
        {
            var respuesta = modelo.Editar(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("ConsultarRoles", "Rol");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult EliminarRol(string id)
        {
            var respuesta = modelo.Eliminar(id);

            if (respuesta.Codigo == 0)
                return RedirectToAction("ConsultarRoles", "Rol");
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
    }
}