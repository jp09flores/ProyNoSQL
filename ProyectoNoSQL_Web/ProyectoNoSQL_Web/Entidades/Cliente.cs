using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Web.Entidades
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaInicioMembresia { get; set; }

    }

    public class ConfirmacionCliente
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<Cliente> Datos { get; set; }
        public Cliente Dato { get; set; }
    }
}