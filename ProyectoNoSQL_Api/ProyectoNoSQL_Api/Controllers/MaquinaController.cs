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
    public class MaquinaController : ApiController
    {
        private readonly IMongoCollection<Maquina> maquinaCollection;

        public MaquinaController()
        {
            string connectionString = ConfigurationManager.AppSettings["ConexionMongo"];
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Gimnasio");
            maquinaCollection = database.GetCollection<Maquina>("maquinas");
        }

        // -----------------------------------------------------------------------------------
        [HttpGet]
        [Route("Maquina/Mostrar")]
        public ConfirmacionMaquina ConsultarDatosMaquinas()
        {
            var respuesta = new ConfirmacionMaquina();

            try
            {
                var datos = maquinaCollection.Find(_ => true).ToList();

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
        [Route("Maquina/MostrarUno")]
        public ConfirmacionMaquina ConsultarUnDatoMaquina(string id)
        {
            var respuesta = new ConfirmacionMaquina();

            try
            {
                var dato = maquinaCollection.Find(d => d.Id == id).FirstOrDefault();

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
        [Route("Maquina/Nuevo")]
        public Confirmacion NuevoDatoMaquina(Maquina entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                maquinaCollection.InsertOne(entidad);

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
        [Route("Maquina/Editar")]
        public async Task<Confirmacion> EditarDatoMaquina(Maquina entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Maquina>.Filter.Eq("_id", ObjectId.Parse(entidad.Id));
                var update = Builders<Maquina>.Update
                    .Set(c => c.NombreMaquina, entidad.NombreMaquina)
                    .Set(c => c.Descripcion, entidad.Descripcion)
                    .Set(c => c.Estado, entidad.Estado);

                var result = await maquinaCollection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = "Datos de maquinas actualizados correctamente";
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
        [Route("Maquina/Eliminar")]
        public async Task<Confirmacion> EliminarDatoMaquina(string id)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Maquina>.Filter.Eq("_id", ObjectId.Parse(id));
                var resultado = await maquinaCollection.DeleteOneAsync(filter);

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
