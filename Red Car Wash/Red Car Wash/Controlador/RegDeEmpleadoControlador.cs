using Newtonsoft.Json;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Red_Car_Wash.Controlador
{
    public class RegDeEmpleadoControlador
    {
        public async Task<List<RegEmpleadoModelo>> MetodoSeleccionarRegEmpleado(long ide)
        {
            List<RegEmpleadoModelo> listaResultante = new List<RegEmpleadoModelo>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_regDeEmpleado/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<RegEmpleadoModelo>)JsonConvert.DeserializeObject(json, typeof(List<RegEmpleadoModelo>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarRegEmpleado(long id, DateTimeOffset fecha, string nombres, string apellidos, string cedula, float sueldo, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new RegEmpleadoModelo
                {
                    id_re = id,
                    fecha_re = fecha,
                    nombres_re = nombres,
                    apellidos_re = apellidos,
                    cedula_re = cedula,
                    sueldoAcordado_re = sueldo,
                    id_uc_re = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_regDeEmpleado/{id}"));
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

        public async Task<string> MetodoInsertarRegEmpleado(DateTimeOffset fecha, string nombres, string apellidos, string cedula, float sueldo, long id_uc)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new RegEmpleadoModelo
                {
                    fecha_re = fecha,
                    nombres_re = nombres,
                    apellidos_re = apellidos,
                    cedula_re = cedula,
                    sueldoAcordado_re = sueldo,
                    id_uc_re = id_uc
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_regDeEmpleado/"));
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

        public async Task<string> MetodoEliminarRegEmpleado(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_regDeEmpleado/{id}"));
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
