using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class PersonalControlador
    {
        public async Task<List<PersonalModeloVista>> MetodoSeleccionarPersonal(long ide)
        {
            List<PersonalModeloVista> listaResultante = new List<PersonalModeloVista>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_personal/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<PersonalModeloVista>)JsonConvert.DeserializeObject(json, typeof(List<PersonalModeloVista>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarPersonal(long id, DateTimeOffset fecha, long id_re, long id_tdp, float valor, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new PersonalModelo
                {
                    id_personal = id,
                    fecha_personal = fecha,
                    id_re_personal = id_re,
                    id_tdp_personal = id_tdp,
                    valor_personal = valor,
                    id_uc_personal = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_personal/{id}"));
                var cliente = new HttpClient();
                var resultado = await cliente.PutAsync(uri, content);
                if (resultado.IsSuccessStatusCode)
                {
                    mensaje = "Actualización correcta";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return mensaje;
        }

        public async Task<string> MetodoInsertarPersonal(DateTimeOffset fecha, long id_re, long id_tdp, float valor, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new PersonalModelo
                {
                    fecha_personal = fecha,
                    id_re_personal = id_re,
                    id_tdp_personal = id_tdp,
                    valor_personal = valor,
                    id_uc_personal = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_personal/"));
                var cliente = new HttpClient();
                var resultado = await cliente.PostAsync(uri, content);
                if (resultado.IsSuccessStatusCode)
                {
                    mensaje = "Ingreso correcto";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return mensaje;
        }

        public async Task<string> MetodoEliminarPersonal(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_personal/{id}"));
                var cliente = new HttpClient();
                var resultado = await cliente.DeleteAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    mensaje = "Eliminación correcta";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return mensaje;
        }
    }
}
