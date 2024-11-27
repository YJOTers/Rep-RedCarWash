using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class RegDeVehiculoControlador
    {
        public async Task<List<RegDeVehiculoModeloVista>> MetodoSeleccionarRegDeVehiculo(long ide)
        {
            List<RegDeVehiculoModeloVista> listaResultante = new List<RegDeVehiculoModeloVista>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_regDeVehiculo/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<RegDeVehiculoModeloVista>)JsonConvert.DeserializeObject(json, typeof(List<RegDeVehiculoModeloVista>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarRegDeVehiculo(long id, string nombre, string placa, long id_color, long id_marca, long id_tdv, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new RegDeVehiculoModelo
                {
                    id_rv = id,
                    cliente_rv = nombre,
                    placa_rv = placa,
                    id_color_rv = id_color,
                    id_marca_rv = id_marca,
                    id_tdv_rv = id_tdv,
                    id_uc_rv = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_regDeVehiculo/{id}"));
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

        public async Task<string> MetodoInsertarRegDeVehiculo(string nombre, string placa, long id_color, long id_marca, long id_tdv, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new RegDeVehiculoModelo
                {
                    cliente_rv = nombre,
                    placa_rv = placa,
                    id_color_rv = id_color,
                    id_marca_rv = id_marca,
                    id_tdv_rv = id_tdv,
                    id_uc_rv = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_regDeVehiculo/"));
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

        public async Task<string> MetodoEliminarRegDeVehiculo(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_regDeVehiculo/{id}"));
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
