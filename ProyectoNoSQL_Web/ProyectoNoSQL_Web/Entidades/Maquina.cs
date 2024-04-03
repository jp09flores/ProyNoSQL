using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Web.Entidades
{
    public class Maquina
    {
        public string Id { get; set; }
        public string NombreMaquina { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }

    public class ConfirmacionMaquina
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Maquina> Datos { get; set; }
        public Maquina Dato { get; set; }
    }
}