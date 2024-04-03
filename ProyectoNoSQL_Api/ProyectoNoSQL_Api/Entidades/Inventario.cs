using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNoSQL_Api.Entidades
{
    public class Inventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id_producto")]
        public int IdProducto { get; set; }

        [BsonElement("nombre_producto")]
        public string NombreProducto { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("precio")]
        public decimal Precio { get; set; }

        [BsonElement("cantidad_stock")]
        public int Stock { get; set; }

        [BsonElement("estado")]
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