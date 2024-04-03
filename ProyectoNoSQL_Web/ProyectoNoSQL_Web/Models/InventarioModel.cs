using ProyectoNoSQL_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace ProyectoNoSQL_Web.Models
{
    public class InventarioModel
    {
        public string url = ConfigurationManager.AppSettings["urlApi"];

        // ------------------------------------------------------

        public ConfirmacionInventario ConsultarDatosInventario()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"] + "Inventario/Mostrar";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionInventario>().Result;
                else
                    return null;
            }
        }

        // ------------------------------------------------------

        public Confirmacion NuevoDatosInventario(Inventario entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Inventario/Nuevo";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        // ------------------------------------------------------

        public ConfirmacionInventario ConsultarUnDato(string id)
        {
            using (var client = new HttpClient())
            {
                url += "Inventario/MostrarUno?id=" + id;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionInventario>().Result;
                else
                    return null;
            }
        }

        public Confirmacion Editar(Inventario entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Inventario/Editar";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        // ------------------------------------------------------
        public Confirmacion Eliminar(string id)
        {
            using (var client = new HttpClient())
            {
                url += "Inventario/Eliminar?id=" + id;
                var respuesta = client.DeleteAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }
    }
}