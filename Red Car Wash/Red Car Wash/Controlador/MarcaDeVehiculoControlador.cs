using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class MarcaDeVehiculoControlador
    {
        public async Task<List<MarcaDeVehiculoModelo>> MetodoSeleccionarMarcaDeVehiculo(long ide)
        {
            List<MarcaDeVehiculoModelo> listaResultante = new List<MarcaDeVehiculoModelo>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_marcaDeVehiculo/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<MarcaDeVehiculoModelo>)JsonConvert.DeserializeObject(json, typeof(List<MarcaDeVehiculoModelo>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarMarcaDeVehiculo(long id, string marca, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new MarcaDeVehiculoModelo
                {
                    id_marca = id,
                    nombreMarca_marca = marca,
                    id_uc_marca = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_marcaDeVehiculo/{id}"));
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

        public async Task<string> MetodoInsertarMarcaDeVehiculo(string marca, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new MarcaDeVehiculoModelo
                {
                    nombreMarca_marca = marca,
                    id_uc_marca = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_marcaDeVehiculo/"));
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

        public async Task<string> MetodoEliminarMarcaDeVehiculo(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_marcaDeVehiculo/{id}"));
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
