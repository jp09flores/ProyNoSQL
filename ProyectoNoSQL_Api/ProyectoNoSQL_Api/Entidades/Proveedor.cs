using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Api.Entidades
{
    public class Proveedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre_proveedor")]
        public string NombreProveedor { get; set; }

        [BsonElement("direccion")]
        public string DireccionProveedor { get; set; }

        [BsonElement("telefono")]
        public string TelefonoProveedor { get; set; }

        [BsonElement("email")]
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