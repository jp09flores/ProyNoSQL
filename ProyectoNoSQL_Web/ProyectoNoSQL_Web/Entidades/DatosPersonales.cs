using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Web.Entidades
{
    public class DatosPersonales
    {
       
        public string Id { get; set; }
        public string Cedula { get; set; }

    
        public string Nombre { get; set; }

   
        public string ApellidoP { get; set; }


        public string ApellidoM { get; set; }

      
        public int Edad { get; set; }

     
        public string Genero { get; set; }


        public DateTime Fecha { get; set; }

    }

    public class ConfirmacionDatosPersonales
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
        public List<DatosPersonales> Datos { get; set; }
        public DatosPersonales Dato { get; set; }
    }
}