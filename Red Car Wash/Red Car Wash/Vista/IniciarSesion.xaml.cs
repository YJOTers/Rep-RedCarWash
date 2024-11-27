using Red_Car_Wash.Controlador;
using Acr.UserDialogs;
using System;
using Xamarin.Forms;

namespace Red_Car_Wash.Vista
{
    public partial class IniciarSesion : ContentPage
    {
        bool verClave = false;
        public IniciarSesion()
        {
            InitializeComponent();
            VerificarInicioDeSesion();
        }

        private void BtnVerClave(object sender, EventArgs e)
        {
            Clave.IsPassword = false;
            if (verClave) 
            {
                Clave.IsPassword = true;
                verClave = false;
            }
            else 
            {
                verClave = true;
            }
        }

        private void BtnIniciarSesion(object sender, EventArgs e)
        {
            MetodoIniciarSesion(Correo.Text, Clave.Text);
        }

        private void BtnRegistrarse(object sender, EventArgs e) 
        {
            _ = Navigation.PushAsync(new Registrarse());
        }

        private void BtnRecuperarClave(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new RecuperarClave());
        }

        public async void MetodoIniciarSesion(string correo, string clave) 
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
            }
            else 
            {
                UsuarioControlador ob = new UsuarioControlador();
                var Usuarios = await ob.MetodoSeleccionarUsuario(correo, clave);
                if (Usuarios.Count == 0)
                {
                    _ = UserDialogs.Instance.Alert("Usuario no encontrado", "ADVERTENCIA", "ENTENDIDO");
                }
                else 
                {
                    var mensaje = TipoDeCuenta.ValidarSuscripcion(Usuarios[0]);
                    if (mensaje != "-1")
                    {
                        _ = UserDialogs.Instance.Alert(mensaje);
                        Usuarios = await ob.MetodoSeleccionarUsuario(correo, clave);
                    }
                    DatosPersistentes.GuardarDatos(correo, clave);
                    _ = Navigation.PushAsync(new Inicio(Usuarios[0]));
                    Navigation.RemovePage(this);
                }
            }
        }

        public void VerificarInicioDeSesion() 
        {
            var datos = DatosPersistentes.ObtenerDatos();
            if (!string.IsNullOrEmpty(datos[0]) & !string.IsNullOrEmpty(datos[1])) 
            {
                MetodoIniciarSesion(datos[0], datos[1]);
            }
        }
    }
}
