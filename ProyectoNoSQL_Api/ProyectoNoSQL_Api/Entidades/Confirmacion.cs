using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Api.Entidades
{
    public class Confirmacion
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }
    }
}