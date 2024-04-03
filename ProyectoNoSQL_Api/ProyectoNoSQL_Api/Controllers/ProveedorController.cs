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
    public class ProveedorController : ApiController
    {
        private readonly IMongoCollection<Proveedor> proveedorCollection;

        public ProveedorController()
        {
            string connectionString = ConfigurationManager.AppSettings["ConexionMongo"];
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Gimnasio");
            proveedorCollection = database.GetCollection<Proveedor>("proveedores");
        }

        // -----------------------------------------------------------------------------------
        [HttpGet]
        [Route("Proveedor/Mostrar")]
        public ConfirmacionProveedor ConsultarDatosMaquinas()
        {
            var respuesta = new ConfirmacionProveedor();

            try
            {
                var datos = proveedorCollection.Find(_ => true).ToList();

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
        [Route("Proveedor/MostrarUno")]
        public ConfirmacionProveedor ConsultarUnDatoMaquina(string id)
        {
            var respuesta = new ConfirmacionProveedor();

            try
            {
                var dato = proveedorCollection.Find(d => d.Id == id).FirstOrDefault();

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
        [Route("Proveedor/Nuevo")]
        public Confirmacion NuevoDatoMaquina(Proveedor entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                proveedorCollection.InsertOne(entidad);

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
        [Route("Proveedor/Editar")]
        public async Task<Confirmacion> EditarDatoMaquina(Proveedor entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Proveedor>.Filter.Eq("_id", ObjectId.Parse(entidad.Id));
                var update = Builders<Proveedor>.Update
                    .Set(c => c.NombreProveedor, entidad.NombreProveedor)
                    .Set(c => c.DireccionProveedor, entidad.DireccionProveedor)
                    .Set(c => c.TelefonoProveedor, entidad.TelefonoProveedor)
                    .Set(c => c.EmailProveedor, entidad.EmailProveedor);

                var result = await proveedorCollection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = "Datos de proveedores actualizados correctamente";
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
        [Route("Proveedor/Eliminar")]
        public async Task<Confirmacion> EliminarDatoMaquina(string id)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Proveedor>.Filter.Eq("_id", ObjectId.Parse(id));
                var resultado = await proveedorCollection.DeleteOneAsync(filter);

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
