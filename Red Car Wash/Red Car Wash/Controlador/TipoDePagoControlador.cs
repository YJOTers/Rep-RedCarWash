using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class TipoDePagoControlador
    {
        public async Task<List<TipoDePagoModelo>> MetodoSeleccionarTipoDePago(long ide)
        {
            List<TipoDePagoModelo> listaResultante = new List<TipoDePagoModelo>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_tipoDePago/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<TipoDePagoModelo>)JsonConvert.DeserializeObject(json, typeof(List<TipoDePagoModelo>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarTipoDePago(long id, string tipo, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new TipoDePagoModelo
                {
                    id_tdp = id,
                    tipoDePago_tdp = tipo,
                    id_uc_tdp = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_tipoDePago/{id}"));
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

        public async Task<string> MetodoInsertarTipoDePago(string tipo, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new TipoDePagoModelo
                {
                    tipoDePago_tdp = tipo,
                    id_uc_tdp = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_tipoDePago/"));
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

        public async Task<string> MetodoEliminarTipoDePago(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_tipoDePago/{id}"));
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
