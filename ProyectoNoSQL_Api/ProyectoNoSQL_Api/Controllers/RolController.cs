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
    public class RolController : ApiController
    {
        private readonly IMongoCollection<Rol> RolCollection;


        public RolController()
        {
            string connectionString = ConfigurationManager.AppSettings["ConexionMongo"];
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Gimnasio");
            RolCollection = database.GetCollection<Rol>("rolEmpleado");
        }

      


        [HttpGet]
        [Route("Rol/Mostrar")]
        public ConfirmacionRol ConsultarDatosRoles()
        {
            var respuesta = new ConfirmacionRol();

            try
            {
               
                    var datos = RolCollection.Find(_ => true).ToList();

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
        [Route("Rol/MostrarUno")]
        public ConfirmacionRol ConsultarUnDato(string id)
        {
            var respuesta = new ConfirmacionRol();

            try
            {
                var dato = RolCollection.Find(d => d.Id == id).FirstOrDefault();

                if (dato != null)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = string.Empty;
                    respuesta.Dato =  dato; 
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
        [HttpPost]
        [Route("Rol/Nuevo")]
        public Confirmacion NuevoDatosRol(Rol entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                RolCollection.InsertOne(entidad);

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
        [Route("Rol/Editar")]
        public async Task<Confirmacion> EditarRol(Rol entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Rol>.Filter.Eq("_id", ObjectId.Parse(entidad.Id));
                var update = Builders<Rol>.Update
                    .Set(r => r.IdRol, entidad.IdRol)
                    .Set(r => r.NombreRol, entidad.NombreRol);

                var result = await RolCollection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = "Datos personales actualizados correctamente";
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
        [Route("Rol/Eliminar")]
        public async Task<Confirmacion> EliminarRolAsync(string id)
        {
            var respuesta = new Confirmacion();

            try
            {
                var filter = Builders<Rol>.Filter.Eq("_id", ObjectId.Parse(id));
                var resultado = await RolCollection.DeleteOneAsync(filter);

                if (resultado.DeletedCount == 1)
                {
                    respuesta.Codigo = 0;
                    respuesta.Detalle = string.Empty;
                }
                else {
                    respuesta.Codigo = -1;
                    respuesta.Detalle ="No se pudo eliminar";
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
