using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class InformeControlador
    {
        public async Task<List<InformeModelo>> MetodoSeleccionarInforme(long ide)
        {
            List<InformeModelo> listaResultante = new List<InformeModelo>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_informe/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<InformeModelo>)JsonConvert.DeserializeObject(json, typeof(List<InformeModelo>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoInsertarInforme(DateTimeOffset fecha, string actividad, string tipo, string usuario, float total, long ide)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new InformeModelo
                {
                    fecha_inf = fecha,
                    actividad_inf = actividad,
                    tipo_inf = tipo,
                    usuario_inf = usuario,
                    total_inf = total,
                    id_uc_inf = ide
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_informe/"));
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
    }
}
