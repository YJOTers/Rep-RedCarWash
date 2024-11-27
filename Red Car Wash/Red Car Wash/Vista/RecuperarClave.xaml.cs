using Acr.UserDialogs;
using Red_Car_Wash.Controlador;
using System;
using System.Net;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecuperarClave : ContentPage
    {
        public RecuperarClave()
        {
            InitializeComponent();
        }

        private void BtnRecuperarClave(object sender, EventArgs e) 
        {
            MetodoRecuperarClave(Correo.Text);
        }

        public async void MetodoRecuperarClave(string correo) 
        {
            try
            {
                if (string.IsNullOrEmpty(correo))
                {
                    _ = UserDialogs.Instance.Alert("No ha ingresado ningun correo", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    UsuarioControlador ob = new UsuarioControlador();
                    var Usuarios = await ob.MetodoSeleccionarUsuarioPorCorreo(correo);
                    if (Usuarios.Count == 0)
                    {
                        _ = UserDialogs.Instance.Alert("El correo no esta vinculado a ningun obUsuario", "ADVERTENCIA", "ENTENDIDO");
                    }
                    else
                    {
                        var valorRandom = new Random().Next(10000, 99999);
                        var mensaje = new MailMessage(
                            "corisi_apps@outlook.com",
                            correo,
                            "RECUPERAR CLAVE",
                            $"<h2><b>SU NUEVA CLAVE TEMPORAL ES LA SIGUIENTE:</b> {valorRandom}</h2><br><h2>No olvides actualizar tu clave por una que recuerdes</h2>");
                        mensaje.IsBodyHtml = true;
                        var smtp = new SmtpClient
                        {
                            Port = 587,
                            Host = "smtp.office365.com",
                            EnableSsl = true,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential("corisi_apps@outlook.com", "CoApps%1000")
                        };
                        smtp.Send(mensaje);
                        string respuesta = await ob.MetodoActualizarUsuario(Usuarios[0].id_uc, Usuarios[0].usuario_uc, Usuarios[0].correo_uc, valorRandom.ToString(), Usuarios[0].tipoCuenta_uc, Usuarios[0].fechaCaducidad_uc, Usuarios[0].idEmpleado_uc);
                        if (respuesta != "-1")
                        {
                            _ = UserDialogs.Instance.Toast(respuesta);
                        }
                    }
                }
            }
            catch (Exception ex) { await DisplayAlert("Error", ex.Message, "OK"); }
        }
    }
}