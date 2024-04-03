using ProyectoNoSQL_Web.Entidades;
using ProyectoNoSQL_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoNoSQL_Web.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel modelo = new UsuarioModel();
        
        [HttpGet]
        public ActionResult InicioSesion()
        {
            return View();
        }


        [HttpPost]
        public ActionResult InicioSesion(Empleado entidad)
        {
            var respuesta = modelo.IniciarSesion(entidad);

            if (respuesta.Codigo == 0)
            {
                Session["NombreUsuario"] = respuesta.Dato.Email;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }
        [FiltroSeguridad]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("InicioSesion", "Usuario");
        }

    }
}
