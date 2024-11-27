using Acr.UserDialogs;
using Red_Car_Wash.Controlador;
using Red_Car_Wash.Modelo;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioEmpleado : ContentPage
    {
        UsuarioControlador ob = new UsuarioControlador();
        UsuarioModelo Empleado = null;

        public UsuarioEmpleado(UsuarioModelo Empleado)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(Empleado.tipoCuenta_uc);
            this.Empleado = Empleado;
            RefrescarDatos();
        }

        private void BtnActualizar(object sender, EventArgs e)
        {
            ActualizarUsuario(Usuario.Text, Correo.Text, Clave.Text);
        }

        public async void ActualizarUsuario(string usuario, string correo, string clave)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
            }
            else
            {
                string mensaje = await ob.MetodoActualizarUsuario(Empleado.id_uc, usuario, correo, clave, Empleado.tipoCuenta_uc, Empleado.fechaCaducidad_uc, Empleado.idEmpleado_uc);
                if (mensaje != "-1")
                {
                    DatosPersistentes.EliminarDatos();
                    DatosPersistentes.GuardarDatos(correo, clave);
                    RefrescarDatos();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
        }

        public async void RefrescarDatos()
        {
            string[] datos = DatosPersistentes.ObtenerDatos();
            var datosUsuario = await ob.MetodoSeleccionarUsuario(datos[0], datos[1]);
            Usuario.Text = datosUsuario[0].usuario_uc;
            Correo.Text = datosUsuario[0].correo_uc;
            Clave.Text = datosUsuario[0].clave_uc;
        }
    }
}