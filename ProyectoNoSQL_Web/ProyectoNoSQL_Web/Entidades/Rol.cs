using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Web.Entidades
{
    public class Rol
    {

        public string Id { get; set; }

        public int IdRol { get; set; }

        public string NombreRol { get; set; }

    }

    public class ConfirmacionRol
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Rol> Datos { get; set; }
        public Rol Dato { get; set; }
    }
}