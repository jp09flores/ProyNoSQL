using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Api.Entidades
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("apellido")]
        public string Apellido { get; set; }

        [BsonElement("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [BsonElement("genero")]
        public string Genero { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; }

        [BsonElement("telefono")]
        public string Telefono { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("fecha_inicio_membresia")]
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