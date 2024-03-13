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
    public class DatosPersonalesModel
    {

        public string url = ConfigurationManager.AppSettings["urlApi"];

        public ConfirmacionDatosPersonales ConsultarDatosPersonales()
        {
            using (var client = new HttpClient())
            {
                url += "DatosPersonales/Mostrar";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionDatosPersonales>().Result;
                else
                    return null;
            }
        }

        public Confirmacion NuevoDatosPersonales(DatosPersonales datosPersonales)
        {
            using (var client = new HttpClient())
            {
                url += "DatosPersonales/Nuevo";
                JsonContent jsonEntidad = JsonContent.Create(datosPersonales);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionDatosPersonales ConsultarUnDato(string id)
        {
            using (var client = new HttpClient())
            {
                url += "DatosPersonales/Mostrar/" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionDatosPersonales>().Result;
                else
                    return null;
            }
        }
        public Confirmacion Editar(DatosPersonales datosPersonales)
        {
            using (var client = new HttpClient())
            {
                url += "DatosPersonales/Editar";
                JsonContent jsonEntidad = JsonContent.Create(datosPersonales);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
        public Confirmacion Eliminar (DatosPersonales datosPersonales)
        {
            using (var client = new HttpClient())
            {
                url += "DatosPersonales/Eliminar";
                JsonContent jsonEntidad = JsonContent.Create(datosPersonales);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
    }
}