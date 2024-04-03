using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Web.Entidades
{
    public class Proveedor
    {
        public string Id { get; set; }
        public string NombreProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string EmailProveedor { get; set; }
    }

    public class ConfirmacionProveedor
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Proveedor> Datos { get; set; }
        public Proveedor Dato { get; set; }
    }
}