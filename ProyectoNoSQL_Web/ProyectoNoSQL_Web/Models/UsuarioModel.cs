
using ProyectoNoSQL_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoNoSQL_Web.Models
{
    public class UsuarioModel
    {

        public string url = ConfigurationManager.AppSettings["urlApi"];



        public ConfirmacionEmpleado IniciarSesion(Empleado entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Usuario/InicioSesion";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionEmpleado>().Result;
                else
                    return null;
            }
        }
    }
}