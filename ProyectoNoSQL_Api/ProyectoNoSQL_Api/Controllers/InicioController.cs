using MongoDB.Driver;
using ProyectoNoSQL_Api.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoNoSQL_Api.Controllers
{
    public class InicioController : ApiController
    {
        private readonly IMongoCollection<DatosPersonales> datosPersonalesCollection;


        public InicioController()
        {
            string connectionString = ConfigurationManager.AppSettings["ConexionMongo"];
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Personas");
            datosPersonalesCollection = database.GetCollection<DatosPersonales>("DatosPersonales");
        }

      


        [HttpGet]
        [Route("DatosPersonales/Mostrar")]
        public ConfirmacionDatosPersonales ConsultarDatosPersonales()
        {
            var respuesta = new ConfirmacionDatosPersonales();

            try
            {
               
                    var datos = datosPersonalesCollection.Find(_ => true).ToList();

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
        [HttpPost]
        [Route("DatosPersonales/Nuevo")]
        public Confirmacion NuevoDatosPersonales(DatosPersonales datosPersonales)
        {
            var respuesta = new Confirmacion();

            try
            {
                datosPersonalesCollection.InsertOne(datosPersonales);

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
    }
}
