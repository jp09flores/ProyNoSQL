using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Web.Entidades
{
    public class Inventario
    {
        public string Id { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }

    public class ConfirmacionInventario
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Inventario> Datos { get; set; }
        public Inventario Dato { get; set; }
    }
}