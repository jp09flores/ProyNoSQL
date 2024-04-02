using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Api.Entidades
{
    public class Rol
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id_rol")]
        public int IdRol { get; set; }

        [BsonElement("nombre_rol")]
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