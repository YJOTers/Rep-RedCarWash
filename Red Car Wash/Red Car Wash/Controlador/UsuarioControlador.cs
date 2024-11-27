using Newtonsoft.Json;
using System.Net.Http;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace Red_Car_Wash.Controlador
{
    public class UsuarioControlador
    {
        public async Task<List<UsuarioModelo>> MetodoSeleccionarUsuario(string correo, string clave)
        {
            List<UsuarioModelo> listaResultante = new List<UsuarioModelo>();
            try 
            {
                string parametros = JsonConvert.SerializeObject(new UsuarioModelo
                {
                    correo_uc = correo,
                    clave_uc = clave
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_usuario/"));
                var cliente = new HttpClient();
                var resultado = await cliente.PostAsync(uri, content);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<UsuarioModelo>)JsonConvert.DeserializeObject(json, typeof(List<UsuarioModelo>));
                }
                return listaResultante;
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<List<UsuarioModelo>> MetodoSeleccionarListaUsuarios(long ide)
        {
            List<UsuarioModelo> listaResultante = new List<UsuarioModelo>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_listaUsuarios/{ide}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<UsuarioModelo>)JsonConvert.DeserializeObject(json, typeof(List<UsuarioModelo>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<List<UsuarioModelo>> MetodoSeleccionarUsuarioPorCorreo(string correo)
        {
            List<UsuarioModelo> listaResultante = new List<UsuarioModelo>();
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}seleccionar_usuarioPorCorreo/{correo}"));
                var cliente = new HttpClient();
                var resultado = await cliente.GetAsync(uri);
                if (resultado.IsSuccessStatusCode)
                {
                    string json = await resultado.Content.ReadAsStringAsync();
                    listaResultante = (List<UsuarioModelo>)JsonConvert.DeserializeObject(json, typeof(List<UsuarioModelo>));
                }
                return listaResultante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return listaResultante;
            }
        }

        public async Task<string> MetodoActualizarUsuario(long id, string usuario, string correo, string clave, long tipo, DateTimeOffset fecha, long ide)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new UsuarioModelo
                {
                    id_uc = id,
                    usuario_uc = usuario,
                    correo_uc = correo,
                    clave_uc = clave,
                    tipoCuenta_uc = tipo,
                    fechaCaducidad_uc = fecha,
                    idEmpleado_uc = ide
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}actualizar_usuario/{id}"));
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

        public async Task<string> MetodoInsertarUsuario(string usuario, string correo, string clave, long tipo, DateTimeOffset fecha, long ide)
        {
            string mensaje = "-1";
            try
            {
                string parametros = JsonConvert.SerializeObject(new UsuarioModelo
                {
                    usuario_uc = usuario,
                    correo_uc = correo,
                    clave_uc = clave,
                    tipoCuenta_uc = tipo,
                    fechaCaducidad_uc = fecha,
                    idEmpleado_uc = ide
                });
                StringContent content = new StringContent(parametros, Encoding.UTF8, "application/json");
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}insertar_usuario/"));
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

        public async Task<string> MetodoEliminarUsuario(long id)
        {
            string mensaje = "-1";
            try
            {
                Uri uri = new Uri(string.Format($"{DireccionApi.URL}eliminar_usuario/{id}"));
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
