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
    public class ClientesModel
    {

        public string url = ConfigurationManager.AppSettings["urlApi"];

        public ConfirmacionCliente ConsultarDatosPersonales()
        {
            using (var client = new HttpClient())
            {
                url += "Clientes/Mostrar";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCliente>().Result;
                else
                    return null;
            }
        }

        public Confirmacion NuevoDatosPersonales(Cliente entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Clientes/Nuevo";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionCliente ConsultarUnDato(string id)
        {
            using (var client = new HttpClient())
            {
                url += "Clientes/Mostrar/" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionCliente>().Result;
                else
                    return null;
            }
        }
        public Confirmacion Editar(Cliente entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Clientes/Editar";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
        public Confirmacion Eliminar (Cliente entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Clientes/Eliminar";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
    }
}