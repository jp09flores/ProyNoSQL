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
    public class RolModel
    {

        public string url = ConfigurationManager.AppSettings["urlApi"];

        public ConfirmacionRol ConsultarRoles()
        {
            using (var client = new HttpClient())
            {
                url += "Rol/Mostrar";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionRol>().Result;
                else
                    return null;
            }
        }

        public Confirmacion NuevoRol(Rol entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Rol/Nuevo";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionRol ConsultarUnDato(string id)
        {
            using (var client = new HttpClient())
            {
                url += "Rol/MostrarUno?id=" +id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionRol>().Result;
                else
                    return null;
            }
        }
        public Confirmacion Editar(Rol entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Rol/Editar";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
        public Confirmacion Eliminar (string id)
        {
            using (var client = new HttpClient())
            {
                url += "Rol/Eliminar?id=" + id;
                var respuesta = client.DeleteAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
    }
}