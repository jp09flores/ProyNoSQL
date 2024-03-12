using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Api.Entidades
{
    public class DatosPersonales
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Cedula")]
        public string Cedula { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Apellido_P")]
        public string ApellidoP { get; set; }

        [BsonElement("Apellido_M")]
        public string ApellidoM { get; set; }

        [BsonElement("Edad")]
        public int Edad { get; set; }

        [BsonElement("Genero")]
        public string Genero { get; set; }

        [BsonElement("Fecha")]
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