using Red_Car_Wash.Controlador;
using Red_Car_Wash.Modelo;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Negocio : ContentPage
    {
        UsuarioModelo obUsuario = null;

        public Negocio(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
        }

        private void BtnServicios(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new Servicios(obUsuario));
        }

        private void BtnInformes(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new Informes(obUsuario));
        }

        private void BtnPersonal(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new Personal(obUsuario));
        }
    }
}