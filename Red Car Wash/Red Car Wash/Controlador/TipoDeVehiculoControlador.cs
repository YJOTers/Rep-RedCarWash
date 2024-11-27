using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class TipoDeVehiculoControlador
    {
        public async Task<List<TipoDeVehiculoModelo>> MetodoSeleccionarTipoDeVehiculo(long ide)
        {
            List<TipoDeVehiculoModelo> listaResultante = new List<TipoDeVehiculoModelo>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_tipoDeVehiculo/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<TipoDeVehiculoModelo>)JsonConvert.DeserializeObject(json, typeof(List<TipoDeVehiculoModelo>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarTipoDeVehiculo(long id, string tipo, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new TipoDeVehiculoModelo
                {
                    id_tdv = id,
                    tipoDeVehiculo_tdv = tipo,
                    id_uc_tdv = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_tipoDeVehiculo/{id}"));
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

        public async Task<string> MetodoInsertarTipoDeVehiculo(string tipo, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new TipoDeVehiculoModelo
                {
                    tipoDeVehiculo_tdv = tipo,
                    id_uc_tdv = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_tipoDeVehiculo/"));
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

        public async Task<string> MetodoEliminarTipoDeVehiculo(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_tipoDeVehiculo/{id}"));
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
