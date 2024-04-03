using MongoDB.Bson;
using MongoDB.Driver;
using ProyectoNoSQL_Api.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProyectoNoSQL_Api.Controllers
{
    public class InventarioController : ApiController
    {
        private readonly IMongoCollection<Inventario> inventarioCollection;

        public InventarioController()
        {
            string connectionString = ConfigurationManager.AppSettings["ConexionMongo"];
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Gimnasio");
            inventarioCollection = database.GetCollection<Inventario>("inventario");
        }

        // -----------------------------------------------------------------------------------
        [HttpGet]
        [Route("Inventario/Mostrar")]
        public ConfirmacionInventario ConsultarDatosInventario()
        {
            var respuesta = new ConfirmacionInventario();

            try
            {
                var datos = inventarioCollection.Find(_ => true).ToList();

                if (datos.Count > 0)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = string.Empty;
                    respuesta.Datos = datos;
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Detalle = "No se encontraron resultados";
                }

            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Inventario/MostrarUno")]
        public ConfirmacionInventario ConsultarUnDatoInventario(string id)
        {
            var respuesta = new ConfirmacionInventario();

            try
            {
                var dato = inventarioCollection.Find(d => d.Id == id).FirstOrDefault();

                if (dato != null)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = string.Empty;
                    respuesta.Dato = dato;
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Detalle = "No se encontraron resultados";
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        // -----------------------------------------------------------------------------------
        [HttpPost]
        [Route("Inventario/Nuevo")]
        public Confirmacion NuevoDatoInventario(Inventario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                inventarioCollection.InsertOne(entidad);

                respuesta.Codigo = 0;
                respuesta.Detalle = string.Empty;
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema: " + ex.Message;
            }

            return respuesta;
        }

        [HttpPut]
        [Route("Inventario/Editar")]
        public async Task<Confirmacion> EditarDatoInventario(Inventario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Inventario>.Filter.Eq("_id", ObjectId.Parse(entidad.Id));
                var update = Builders<Inventario>.Update
                    .Set(c => c.NombreProducto, entidad.NombreProducto)
                    .Set(c => c.Descripcion, entidad.Descripcion)
                    .Set(c => c.Precio, entidad.Precio)
                    .Set(c => c.Stock, entidad.Stock)
                    .Set(c => c.Estado, entidad.Estado);

                var result = await inventarioCollection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = "Datos de inventario actualizados correctamente";
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Detalle = "No se encontró ningún registro para actualizar";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema: " + ex.Message;
            }

            return respuesta;
        }

        [HttpDelete]
        [Route("Inventario/Eliminar")]
        public async Task<Confirmacion> EliminarDatoInventario(string id)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Inventario>.Filter.Eq("_id", ObjectId.Parse(id));
                var resultado = await inventarioCollection.DeleteOneAsync(filter);

                if (resultado.DeletedCount == 1)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = string.Empty;
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Detalle = "No se pudo eliminar";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema: " + ex.Message;
            }

            return respuesta;
        }
    }
}
