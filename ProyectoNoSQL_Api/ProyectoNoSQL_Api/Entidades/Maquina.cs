using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Api.Entidades
{
    public class Maquina
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre_maquina")]
        public string NombreMaquina { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("estado")]
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