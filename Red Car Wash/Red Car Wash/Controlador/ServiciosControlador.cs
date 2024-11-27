using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class ServiciosControlador
    {
        public async Task<List<ServiciosModeloVista>> MetodoSeleccionarServicios(long ide)
        {
            List<ServiciosModeloVista> listaResultante = new List<ServiciosModeloVista>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_servicios/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<ServiciosModeloVista>)JsonConvert.DeserializeObject(json, typeof(List<ServiciosModeloVista>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarServicios(long id, DateTimeOffset fecha, long id_rv, long id_rtl, float precioPagado, float precioPendiente, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new ServiciosModelo
                {
                    id_servicios = id,
                    fecha_servicios = fecha,
                    id_rv_servicios = id_rv,
                    id_rtl_servicios = id_rtl,
                    precioPagado_servicios = precioPagado,
                    precioPendiente_servicios = precioPendiente,
                    id_uc_servicios = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_servicios/{id}"));
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

        public async Task<string> MetodoInsertarServicios(DateTimeOffset fecha, long id_rv, long id_rtl, float precioPagado, float precioPendiente, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new ServiciosModelo
                {
                    fecha_servicios = fecha,
                    id_rv_servicios = id_rv,
                    id_rtl_servicios = id_rtl,
                    precioPagado_servicios = precioPagado,
                    precioPendiente_servicios = precioPendiente,
                    id_uc_servicios = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_servicios/"));
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

        public async Task<string> MetodoEliminarServicios(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_servicios/{id}"));
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
