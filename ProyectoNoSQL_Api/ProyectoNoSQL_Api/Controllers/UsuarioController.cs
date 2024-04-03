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
    public class UsuarioController : ApiController
    {
        private readonly IMongoCollection<Empleado> UsuarioCollection;


        public UsuarioController()
        {
            string connectionString = ConfigurationManager.AppSettings["ConexionMongo"];
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("Gimnasio");
            UsuarioCollection = database.GetCollection<Empleado>("empleados");
        }


        [HttpPost]
        [Route("Usuario/InicioSesion")]
        public ConfirmacionEmpleado InicioSesion(Empleado entidad)
        {
            var respuesta = new ConfirmacionEmpleado();

            try
            {
                var dato = UsuarioCollection.Find(c => c.Email == entidad.Email && c.Contrasena == entidad.Contrasena).FirstOrDefault();


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
       
    }
}

