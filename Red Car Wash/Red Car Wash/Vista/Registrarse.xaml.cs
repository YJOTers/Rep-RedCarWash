using Acr.UserDialogs;
using Red_Car_Wash.Controlador;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrarse : ContentPage
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void BtnRegistrarse(object sender, EventArgs e)
        {
            RegistrarUsuario(Usuario.Text, Correo.Text, Clave.Text);
        }

        public async void RegistrarUsuario(string usuario, string correo, string clave)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
            }
            else
            {
                UsuarioControlador ob = new UsuarioControlador();
                var Usuarios = await ob.MetodoSeleccionarUsuario(correo, clave);
                if (Usuarios.Count == 0)
                {
                    string mensaje = await ob.MetodoInsertarUsuario(usuario, correo, clave, 1, DateTimeOffset.Parse("2021-01-01"), 0);
                    if (mensaje != "-1")
                    {
                        _ = UserDialogs.Instance.Toast(mensaje);
                    }
                }
                else
                {
                    _ = UserDialogs.Instance.Alert("El obUsuario ya existe", "ADVERTENCIA", "ENTENDIDO");
                }
            }
        }
    }
}